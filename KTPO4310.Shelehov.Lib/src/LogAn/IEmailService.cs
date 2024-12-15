namespace KTPO4310.Shelehov.Lib.LogAn;

public interface IEmailService
{
    void SendEmail(string to, string subject, string body);
}