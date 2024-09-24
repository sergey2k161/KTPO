using KTPO4310.Shelehov.Lib.LogAn;
using NUnit.Framework;

namespace KTPO4310.Shelehov.UnitTest.Sample;


[TestFixture]
public class LogAnalyzerTest
{
    [Test]
    public void IsValidLogFileName_BadExtension_ReturnsFalse()
    {
        LogAnalyzer analyzer = new LogAnalyzer();
        
        bool result = analyzer.IsValidLogFileName("file.ShelehovSR");
        Assert.False(result);
    }
    
    [Test]
    public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue()
    {
        LogAnalyzer analyzer = new LogAnalyzer();
        
        bool result = analyzer.IsValidLogFileName("file.SHELEHOVSR");
        Assert.False(result);
    }
    
    [Test]
    public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
    {
        LogAnalyzer analyzer = new LogAnalyzer();
        
        bool result = analyzer.IsValidLogFileName("file.shelehovsr");
        Assert.False(result);
    }
    [TestCase("file.shelehovsr")]
    [TestCase("file.SHELEHOVSR")]
    public void IsValidLogFileName_ValidExtension_ReturnsTrue(string file)
    {
        LogAnalyzer analyzer = new LogAnalyzer();
        
        bool result = analyzer.IsValidLogFileName(file);
        Assert.False(result);
    }

    [Test]
    public void IsValidLogFileName_EmptyFileName_ThrowsException()
    {
        LogAnalyzer analyzer = new LogAnalyzer();
    
        var ex = Assert.Catch<Exception>(() => analyzer.IsValidLogFileName(""));
        
        StringAssert.Contains("Filename is null or empty", ex.Message);
    }

    [TestCase("file.ShelehovSR", false)]
    [TestCase("file.dadada", true)]
    public void IsValidLogFileName_WhenCalled_ChangeWasLastFileNameValid(string file, bool result)
    {
        LogAnalyzer analyzer = new LogAnalyzer();

        analyzer.IsValidLogFileName(file);

        Assert.AreEqual(result, analyzer.WasLastFileNameValid); 
    }
    
}