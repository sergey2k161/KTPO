using KTPO4310.Shelehov.Lib.LogAn;
using NUnit.Framework;
namespace KTPO4310.Shelehov.UnitTest.Sample;

public class FileExceptionManagerTest
{
    private IFileExceptionManager _fileExceptionManager;

    [SetUp]
    public void SetUp()
    {
        _fileExceptionManager = new FileExceptionManager();
    }

    [Test]
    public void IsValid_ValidExtension_ReturnsTrue()
    {
        Assert.IsTrue(_fileExceptionManager.IsValid("file.log"));
        Assert.IsTrue(_fileExceptionManager.IsValid("file.txt"));
        Assert.IsTrue(_fileExceptionManager.IsValid("file.exe"));
    }

    [Test]
    public void IsValid_InvalidExtension_ReturnsFalse()
    {
        Assert.IsFalse(_fileExceptionManager.IsValid("file.cs"));
        Assert.IsFalse(_fileExceptionManager.IsValid("file.py"));
    }
}