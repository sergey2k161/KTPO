using KTPO4310.Shelehov.Lib.LogAn;

namespace KTPO4310.Shelehov.Service.LibConfig;

public class LogAnalyzerConfig
{
    private readonly LogAnalyzer _logAnalyzer = new LogAnalyzer();
    
    private string[] testFiles =
    {
        "file.log",
        "file.txt",
        "file.exe",
        "file.exe",
        "file.doc",
        "file.py"
    };
    
    public void TestFiles()
    {
        foreach (string testFile in testFiles)
        {
            bool isValid = _logAnalyzer.IsValidLogFileName(testFile);
            Console.WriteLine($"Файл {testFile} имеет доступ равный - {isValid}");
        }

        Console.ReadLine();
    }
}