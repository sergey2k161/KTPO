using KTPO4310.Shelehov.Lib.LogAn;
using NSubstitute;

namespace KTPO4310.Shelehov.UnitTest.LogAn;

public class LogAnalyzerNSubstituteTests
{
    [Test]
    public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
    {
        IFileExceptionManager fakeExceptionManager = Substitute.For<IFileExceptionManager>();
        
        fakeExceptionManager.IsValid("short.ext").Returns(true);
        ExtensionManagerFactory.SetManager(fakeExceptionManager);

        LogAnalyzer log = new LogAnalyzer();
        bool result = log.IsValidLogFileName("short.ext");
        Assert.True(result);
    }
    
    //Ture or False 
    [Test]
    public void IsValidFileName_NameSupportedExtension_ReturnsFalse()
    {
        IFileExceptionManager fakeExceptionManager = Substitute.For<IFileExceptionManager>();
        
        fakeExceptionManager.IsValid("short.ext").Returns(false);
        ExtensionManagerFactory.SetManager(fakeExceptionManager);

        LogAnalyzer log = new LogAnalyzer();
        bool result = log.IsValidLogFileName("short.ext");
        Assert.False(result);
    }

    [Test]
    public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
    {
        IFileExceptionManager fakeExceptionManager = Substitute.For<IFileExceptionManager>();
        
        fakeExceptionManager.When(x => x.IsValid(Arg.Any<string>()))
            .Do(context =>
            {
                throw new Exception("fake exception");
            });
        ExtensionManagerFactory.SetManager(fakeExceptionManager);

        LogAnalyzer log = new LogAnalyzer();
        
        Assert.False(log.IsValidLogFileName("short.ext"));
    }

    [Test]
    public void Analyze_TooShortFileName_SendsEmail()
    {
        IWebService mockWebService = Substitute.For<IWebService>();
        mockWebService.When(x => x.LogError(Arg.Any<string>()))
            .Do(context =>
            {
                throw new Exception("fake exception");
            });
        WebServiceFactory.SetManager(mockWebService);
        
        IEmailService mockEmailService = Substitute.For<IEmailService>();
        EmailServiceFactory.SetManager(mockEmailService);
        
        LogAnalyzer log = new LogAnalyzer();
        string tooShortFileName = "abc.ext";
        log.Analyze(tooShortFileName);
        
        // mockEmailService.Received().SendEmail("someone@somewhere.com", 
        //     "fake exception", "Невозможно вызвать веб-сервис");
        
        mockEmailService.Received().SendEmail("someone@somewhere.com", 
            "Невозможно вызвать веб-сервис", "fake exception");
    }

    [Test]
    public void Analyze_WebServiceThrows_CallsWebService()
    {
        IWebService mockWebService = Substitute.For<IWebService>();
        WebServiceFactory.SetManager(mockWebService);
        
        LogAnalyzer log = new LogAnalyzer();
        string tooShortFileName = "abc.ext";
        log.Analyze(tooShortFileName);
        
        mockWebService.Received().LogError(Arg.Is<string>(x => x.Contains("abc.ext")));
    }
}