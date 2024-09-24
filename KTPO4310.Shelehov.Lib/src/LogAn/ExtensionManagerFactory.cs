namespace KTPO4310.Shelehov.Lib.LogAn;

public static class ExtensionManagerFactory
{
    private static IFileExceptionManager _fileExceptionManager;
    
    public static void SetManager(IFileExceptionManager fileExceptionManager)
    {
        _fileExceptionManager = fileExceptionManager;
    }
    
    public static IFileExceptionManager Create()
    {
        if (_fileExceptionManager != null)
        {
            return _fileExceptionManager;
        }
        
        return new FileExceptionManager();
    }
    
}