using System.Security.Cryptography.X509Certificates;

namespace KTPO4310.Shelehov.Lib.LogAn;

public class LogAnalyzer
{
    private readonly IFileExceptionManager _fileExceptionManager;

    public LogAnalyzer(IFileExceptionManager fileExceptionManager)
    {
        _fileExceptionManager = fileExceptionManager;
    }
    public bool IsValidLogFileName(string fileName)
    {
        try
        {
            return _fileExceptionManager.IsValid(fileName);
        }
        catch (Exception)
        {
            return false;
        }
    }
    
    
}

