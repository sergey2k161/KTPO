using KTPO4310.Shelehov.Lib.LogAn;

namespace KTPO4310.Shelehov.Lib.SampleCommands;

public class SelfCommandDecorator : ISampleCommands
{
    private readonly ISampleCommands sampleCommands;
    private readonly IView view;
    
    public SelfCommandDecorator(ISampleCommands sampleCommands, IView view)
    {
        this.sampleCommands = sampleCommands;
        this.view = view;
    }
    
    public void Execute()
    {
        try
        {
            sampleCommands.Execute();
        }
        catch (Exception e)
        {
            view.Render($"Exception: {this.GetType()} - {e.Message}");
        }
    }
}