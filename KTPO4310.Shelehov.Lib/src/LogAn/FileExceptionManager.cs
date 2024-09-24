using Microsoft.Extensions.Configuration;

namespace KTPO4310.Shelehov.Lib.LogAn;

public class FileExceptionManager : IFileExceptionManager
{
    private readonly HashSet<string> _validExtensions;

    public FileExceptionManager()
    {
        _validExtensions = LoadValidExtensions();
    }

    private HashSet<string> LoadValidExtensions()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("G:\\All Projects\\C#\\KTPO4310.Shelehov.UnitTest\\KTPO4310.Shelehov.Service\\appsettings.json")
            .Build();
        
        var extensions = configuration.GetSection("ValidExtensions").Get<List<string>>();
        return new HashSet<string>(extensions);
    }
    public bool IsValid(string fileName)
    {
        string extension = Path.GetExtension(fileName);
        return _validExtensions.Contains(extension);
    }
}