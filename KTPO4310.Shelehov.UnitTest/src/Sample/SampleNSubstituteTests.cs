using KTPO4310.Shelehov.Lib.LogAn;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine;
using NSubstitute;

namespace KTPO4310.Shelehov.UnitTest.Sample;

public class SampleNSubstituteTests
{
    [Test]
    public void Returns_ParticularArg_Works()
    {
        // Создание поддельного объекта
        IFileExceptionManager fakeExtensionManager = Substitute.For<IFileExceptionManager>();
        
        fakeExtensionManager.IsValid("short.ext").Returns(true);
        
        bool result = fakeExtensionManager.IsValid("short.ext");
        
        Assert.True(result);
    }
    
    [Test]
    public void Returns_ArgAny_Works()
    {
        // Создание поддельного объекта
        IFileExceptionManager fakeExtensionManager = Substitute.For<IFileExceptionManager>();
        
        fakeExtensionManager.IsValid(Arg.Any<string>()).Returns(true);
        
        bool result = fakeExtensionManager.IsValid("short.ext");
        
        Assert.True(result);
    }

    [Test]
    public void Returns_ArgAny_Throws()
    {
        IFileExceptionManager fakeExtensionManager = Substitute.For<IFileExceptionManager>();

        fakeExtensionManager.When(x => x.IsValid(Arg.Any<string>()))
            .Do(context =>
            {
                throw new Exception("fake exception");
            });
        
        Assert.Throws<Exception>(() => fakeExtensionManager.IsValid("short.ext"));
    }

    [Test]
    public void Received_ParticularArg_Saves()
    {
        IWebService mockWebService = Substitute.For<IWebService>();
        
        mockWebService.LogError("message");
        
        mockWebService.Received().LogError("message");
    }
}