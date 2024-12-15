using KTPO4310.Shelehov.Lib.LogAn;
using NUnit.Framework;

namespace KTPO4310.Shelehov.UnitTest.Sample;


[TestFixture]
public class LogAnalyzerTest
{
    [Test]
    public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
    {
        FakeFileExceptionManager fakeFileExceptionManager = new FakeFileExceptionManager();
        fakeFileExceptionManager.WillBeValid = true;
        ExtensionManagerFactory.SetManager(fakeFileExceptionManager);

        LogAnalyzer logAnalyzer = new LogAnalyzer();
        
        bool result = logAnalyzer.IsValidLogFileName("short.ext");
        
        Assert.True(result);
    }
    
    [Test]
    public void IsValidFileName_NameSupportedExtension_ReturnsFalse()
    {
        FakeFileExceptionManager fakeFileExceptionManager = new FakeFileExceptionManager();
        fakeFileExceptionManager.WillBeValid = false;
        ExtensionManagerFactory.SetManager(fakeFileExceptionManager);

        LogAnalyzer logAnalyzer = new LogAnalyzer();
        
        bool result = logAnalyzer.IsValidLogFileName("short.ext");
        
        Assert.False(result);
    }

    [Test]
    public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
    {
        FakeFileExceptionManager fakeFileExceptionManager = new FakeFileExceptionManager();
        fakeFileExceptionManager.WillThrow = new Exception();
        ExtensionManagerFactory.SetManager(fakeFileExceptionManager);
        
        LogAnalyzer logAnalyzer = new LogAnalyzer();
        
        bool result = logAnalyzer.IsValidLogFileName("short.ext");
        
        Assert.False(result);

    }
    
    [TearDown]
    public void AfterEachTest()
    {
        ExtensionManagerFactory.SetManager(null);
        WebServiceFactory.SetManager(null);
        EmailServiceFactory.SetManager(null);
    }
    
    [Test]
    public void Analyze_WebServiceThrows_SendsEmail()
    {
        FakeWebService stubWebService = new FakeWebService();
        WebServiceFactory.SetManager(stubWebService);
        stubWebService.WillTrowWebError = new Exception(message: "это подделка");
        
        FakeEmailService mockEmail = new FakeEmailService();
        EmailServiceFactory.SetManager(mockEmail);
        
        LogAnalyzer log = new LogAnalyzer();
        string tooShortFileName = "abc.ext";
        
        log.Analyze(tooShortFileName);
        
        StringAssert.Contains(expected: "someone@somewhere.com", actual: mockEmail.To);
        StringAssert.Contains(expected: "это подделка", actual: mockEmail.Message);
        StringAssert.Contains(expected: "Невозможно вызвать веб-сервис", actual: mockEmail.Subject);
    }

    [Test]
    public void Analyze_WhenAnalyzed_FiredEvent()
    {
        bool analyzedFired = false;

        LogAnalyzer logAnalyzer = new LogAnalyzer();
        logAnalyzer.Analyzed += delegate()
        {
            analyzedFired = true;
        };
        
        logAnalyzer.Analyze("short.ext");
        Assert.True(analyzedFired);
    }
}

internal class FakeFileExceptionManager : IFileExceptionManager
{
    public bool WillBeValid = false;
    
    public Exception WillThrow = null;
    
    public bool IsValid(string fileName)
    {
        if (WillThrow != null)
        {
            throw WillThrow;
        }
        return WillBeValid;
    }
}

internal class FakeWebService : IWebService
{
    public string LastError;
    
    public Exception? WillTrowWebError = null;

    public void LogError(string message)
    {
        if (WillTrowWebError != null)
        {
            throw WillTrowWebError;
        }
        LastError = message;
    }
}
