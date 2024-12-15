namespace KTPO4310.Shelehov.Lib.LogAn;

public class Presenter
{
    private readonly ILogAnalyze _logAnalyzer;
    private readonly IView _view;

    public Presenter(ILogAnalyze logAnalyzer, IView view)
    {
        _logAnalyzer = logAnalyzer;
        _view = view;
        
        logAnalyzer.Analyzed += OnLogAnalyzed;
    }
    
    private void OnLogAnalyzed()
    {
        _view.Render("Render is done");
    }
    
}