using KTPO4310.Shelehov.Lib.LogAn;

namespace KTPO4310.Shelehov.Service.Views;

public class ConsoleView : IView
{
    public void Render(string message)
    {
        Console.WriteLine(message);
    }
}