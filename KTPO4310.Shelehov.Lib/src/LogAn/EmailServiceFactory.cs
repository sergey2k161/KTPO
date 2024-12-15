namespace KTPO4310.Shelehov.Lib.LogAn;

public class EmailServiceFactory
{
    private static IEmailService _emailService;

    public static void SetManager(IEmailService emailService)
    {
        _emailService = emailService;
    }
    
    public static IEmailService Create()
    {
        if (_emailService != null)
        {
            return _emailService;
        }
        
        return new EmailService();
    }
}