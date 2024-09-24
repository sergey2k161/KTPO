using System.Security.Cryptography.X509Certificates;

namespace KTPO4310.Shelehov.Lib.LogAn;

public class LogAnalyzer
{
    public bool WasLastFileNameValid { get; set; }
    public bool IsValidLogFileName(string fileName)
    {
        WasLastFileNameValid = false;
        if (string.IsNullOrEmpty(fileName))
        {
            throw new ArgumentNullException("Filename is null or empty");
        }

        if (fileName.EndsWith(".ShelehovSR", StringComparison.CurrentCultureIgnoreCase))
        {
            return false;
        }

        WasLastFileNameValid = true;
        return true;
    }
}