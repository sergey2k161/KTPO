using System.Data;
using KTPO4310.Shelehov.Lib.LogAn;

namespace KTPO4310.Shelehov.Lib.SampleCommands;

public class SecondCommand : ISampleCommands
{
    private readonly IView _view;
    
    public SecondCommand(IView view)
    {
        _view = view;
    }
    
    private int iExecute = 0;
    
    public void Execute()
    {
        iExecute += 1;
        _view.Render($"{this.GetType()
            .ToString()}\nExecute: {iExecute}");

        throw new DataException();
    }
}