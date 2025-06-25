using System.Net;
using System.Net.Mail;

namespace Medical.Office.App.Services;

public class EmailService
{
    private readonly string _smtpServer = "smtp.gmail.com";
    private readonly int _smtpPort = 587;
    private readonly string _smtpUser = "medical.office.service.software@gmail.com";
    private readonly string _smtpPassword = "gixi slrv bsfr aaar";

    public EmailService()
    { }

    private SmtpClient ConfigureSmtpClient()
    {
        return new SmtpClient(_smtpServer)
        {
            Port = _smtpPort,
            Credentials = new NetworkCredential(_smtpUser, _smtpPassword),
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            Timeout = 10000
        };
    }

    public async Task<bool> SendEmailAsync(string toEmail, string subject, string htmlBody)
    {
        try
        {
            using var client = ConfigureSmtpClient();
            using var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpUser),
                Subject = subject,
                Body = htmlBody,
                IsBodyHtml = true
            };
            mailMessage.To.Add(toEmail);

            await client.SendMailAsync(mailMessage);
            Console.WriteLine($"Correo enviado exitosamente a {toEmail}");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al enviar el correo: {ex.Message}");
            return false;
        }
    }
}