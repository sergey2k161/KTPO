using KTPO4310.Shelehov.Lib.LogAn;
using NSubstitute;

namespace KTPO4310.Shelehov.UnitTest.LogAn;

[TestFixture]
public class PresenterTests
{
    [Test]
    public void ctor_WhenAnalyzed_CallsViewRender()
    {
        FakeLogAnalyzer fakeLogAnalyzer = new FakeLogAnalyzer();
        IView fakeView = Substitute.For<IView>();
        Presenter presenter = new Presenter(fakeLogAnalyzer, fakeView);
        
        fakeLogAnalyzer.CallRaiseAnalyzedEvent();
        
        fakeView.Received().Render("Render is done");
    }

    [Test]
    public void ctor_WhenAnalyzed_CallsViewRender_NSubstitute()
    {
        ILogAnalyze mockAnalyze = Substitute.For<ILogAnalyze>();
        IView mockView = Substitute.For<IView>();
        Presenter presenter = new Presenter(mockAnalyze, mockView);
        
        mockAnalyze.Analyzed += Raise.Event<LogAnalyzerAction>();
        
        mockView.Received().Render("Render is done");
    }
}

public class FakeLogAnalyzer : LogAnalyzer
{
    public void CallRaiseAnalyzedEvent()
    {
        base.RaiseAnalyzedEvent();
    }
}