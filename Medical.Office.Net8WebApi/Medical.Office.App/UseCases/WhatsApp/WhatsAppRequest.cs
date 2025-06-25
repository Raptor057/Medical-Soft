using System.ComponentModel.DataAnnotations;

namespace Medical.Office.App.UseCases.WhatsApp;

public class WhatsAppRequest
{
    [Required]
    [Phone]
    public string To { get; set; }
        
    [Required]
    public string TemplateName { get; set; }
        
    [Required]
    public string LanguageCode { get; set; }
}