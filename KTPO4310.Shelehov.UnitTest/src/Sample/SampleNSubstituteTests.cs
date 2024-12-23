using KTPO4310.Shelehov.Lib.LogAn;
using KTPO4310.Shelehov.Lib.SampleCommands;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine;
using NSubstitute;
using NSubstitute.ReceivedExtensions;

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

    [Test]
    public void FirstCommand_Executed()
    {
        IView mockView = Substitute.For<IView>();
        FirstCommand firstCommand = new FirstCommand(mockView);
        
        firstCommand.Execute();
        var iExecute = 1;
        
        mockView.Received().Render($"{firstCommand.GetType().ToString()}\nExecute: {iExecute}");
    }
    
    [Test]
    public void SampleCommandDecorator_Executed()
    {
        IView mockView = Substitute.For<IView>();
        ISampleCommands mockCommand = Substitute.For<ISampleCommands>();

        SampleCommandDecorator decorator = new SampleCommandDecorator(mockCommand, mockView);
        decorator.Execute();
        mockCommand.Received().Execute();
    }

    [Test]
    public void SampleCommandDecorator_Executed2()
    {
        IView mockView = Substitute.For<IView>();
        ISampleCommands mockCommand = Substitute.For<ISampleCommands>();

        SampleCommandDecorator decorator = new SampleCommandDecorator(mockCommand, mockView);
        decorator.Execute();
        mockView.Received().Render($"Start: {decorator.GetType()}");
        mockView.Received().Render($"End: {decorator.GetType()}");
    }
    
    [Test]
    public void SelfCommandDecorator_Executed()
    {
        IView mockView = Substitute.For<IView>();
        ISampleCommands mockCommand = Substitute.For<ISampleCommands>();

        SelfCommandDecorator decorator = new SelfCommandDecorator(mockCommand, mockView);
        decorator.Execute();
        mockCommand.Received().Execute();
    }

    [Test]
    public void SelfCommandDecorator_Executed2()
    {
        IView mockView = Substitute.For<IView>();
        ISampleCommands mockCommand = Substitute.For<ISampleCommands>();

        Exception e = new Exception("Exception");
        
        mockCommand.When(x => x.Execute())
            .Do(context => { throw e;});

        SelfCommandDecorator decorator = new SelfCommandDecorator(mockCommand, mockView);
        
        decorator.Execute();
        mockView.Received().Render($"Exception: {decorator.GetType()} - {e.Message}");
    }
}