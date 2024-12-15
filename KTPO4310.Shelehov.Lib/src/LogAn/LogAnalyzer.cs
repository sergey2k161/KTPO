

namespace KTPO4310.Shelehov.Lib.LogAn;

public class LogAnalyzer : ILogAnalyze
{
    public event LogAnalyzerAction? Analyzed = null;
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

    // public bool Analyze(string fileName)
    // {
    //     if (fileName.Length < 8)
    //     {
    //         try
    //         {
    //             IWebService service = WebServiceFactory.Create();
    //             service.LogError("File name too short: " + fileName);
    //             return false;
    //         }
    //         catch (Exception e)
    //         {
    //             IEmailService emailService = EmailServiceFactory.Create();
    //             emailService.SendEmail(to: "5kqoQ@example.com", subject: "File name too short: " + fileName, message: e.Message);
    //             return false;
    //         }
    //     }
    //     return true;
    // }
    public void Analyze(string fileName)
    {
        if (fileName.Length < 8)
        {
            try
            {   //Передать внешней службе сообщение об ошибке
                IWebService service = WebServiceFactory.Create();
                service.LogError(message: $"Слишком короткое имя файла: {fileName}");
            }
            catch (Exception e)
            {
                IEmailService emailService = EmailServiceFactory.Create();
                emailService.SendEmail(to: "someone@somewhere.com", subject: "Невозможно вызвать веб-сервис", body: e.Message);
            }
        }

        if (Analyzed != null)
        {
            Analyzed();
        }
    }
    
    protected void RaiseAnalyzedEvent()
    {
        if (Analyzed != null)
        {
            Analyzed();
        }
    }
}

