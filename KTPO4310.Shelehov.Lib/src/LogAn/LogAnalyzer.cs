

namespace KTPO4310.Shelehov.Lib.LogAn;

public class LogAnalyzer
{
    // private readonly IFileExceptionManager _fileExceptionManager;
    //
    // public LogAnalyzer(IFileExceptionManager fileExceptionManager)
    // {
    //     _fileExceptionManager = fileExceptionManager;
    // }
    public bool IsValidLogFileName(string fileName)
    {
        IFileExceptionManager fileExceptionManager = ExtensionManagerFactory.Create();
        try
        {
            return fileExceptionManager.IsValid(fileName);
        }
        catch (Exception)
        {
            return false; // Если произошла ошибка, возвращаем false
        }
    }
    
    
}

