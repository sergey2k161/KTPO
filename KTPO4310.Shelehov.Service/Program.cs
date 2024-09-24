using KTPO4310.Shelehov.Service.LibConfig;

namespace KTPO4310.Ivanov.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            LogAnalyzerConfig logAnalyzerConfig = new LogAnalyzerConfig();
            logAnalyzerConfig.TestFiles(); // Вызов метода для проверки файлов
        }
    }
}