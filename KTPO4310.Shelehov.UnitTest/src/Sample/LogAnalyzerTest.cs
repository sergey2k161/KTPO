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