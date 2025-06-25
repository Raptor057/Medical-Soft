using Common.Common.CleanArch;
using Medical.Office.App.Services;
using Medical.Office.App.UseCases.Email.Responses;
using System.Text.RegularExpressions;

namespace Medical.Office.App.UseCases.Email;

public class EmailHandler : IInteractor<EmailRequest, EmailResponse>
{
    private readonly EmailService _emailService;
    private readonly EmailTemplates _emailTemplates;

    public EmailHandler(EmailService emailService, EmailTemplates emailTemplates)
    {
        _emailService = emailService;
        _emailTemplates = emailTemplates;
    }

    public async Task<EmailResponse> Handle(EmailRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Subject) || string.IsNullOrEmpty(request.Body))
        {
            return new FailureEmailResponse("El correo, título y cuerpo son requeridos.");
        }

        string emailPattern = @"^(?<username>[\w\.\-]+)@(?<domain>[\w\-]+)(?<tld>(\.(\w){2,3})+)$";

        if(!Regex.IsMatch(request.Email, emailPattern))
        {
            return new FailureEmailResponse("El correo no es válido.");
        }

        var body = _emailTemplates.GetBasicTemplate(request.Body);

        bool isSent = await _emailService.SendEmailAsync(request.Email, request.Subject, body);

        return isSent 
            ? new SuccessEmailResponse("Correo enviado exitosamente.") 
            : new FailureEmailResponse("Error enviando el correo.");
    }
}