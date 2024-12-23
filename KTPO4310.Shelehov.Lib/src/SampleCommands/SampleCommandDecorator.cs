using KTPO4310.Shelehov.Lib.LogAn;

namespace KTPO4310.Shelehov.Lib.SampleCommands;

public class SampleCommandDecorator : ISampleCommands
{
    private readonly ISampleCommands sampleCommands;
    private readonly IView view;
    
    public SampleCommandDecorator(ISampleCommands sampleCommands, IView view)
    {
        this.sampleCommands = sampleCommands;
        this.view = view;
    }
    public void Execute()
    {
        view.Render("Start: " + this.GetType().ToString());

        try
        {
            sampleCommands.Execute();
        }
        finally
        {
            view.Render("End: " + this.GetType().ToString());
        }
    }
}