namespace KTPO4310.Shelehov.Lib.LogAn;

public interface ILogAnalyze
{
    event LogAnalyzerAction? Analyzed;
    
    bool IsValidLogFileName(string fileName);
    
    void Analyze(string fileName);

}