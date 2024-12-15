namespace KTPO4310.Shelehov.Lib.LogAn;

public class FakeEmailService : IEmailService
{
    public string To { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    
    public void SendEmail(string to, string subject, string message)
    {
        To = to;
        Subject = subject;
        Message = message;
    }
}