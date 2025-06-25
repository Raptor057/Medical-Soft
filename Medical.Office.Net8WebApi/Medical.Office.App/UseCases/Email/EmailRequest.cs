using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Email.Responses;

namespace Medical.Office.App.UseCases.Email;

public class EmailRequest : IRequest<EmailResponse>
{
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }

    public EmailRequest(string email, string subject, string body)
    {
        Email = email;
        Subject = subject;
        Body = body;
    }
}