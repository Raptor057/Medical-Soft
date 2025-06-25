using System.ComponentModel.DataAnnotations;

namespace Medical.Office.Net8WebApi.EndPoints.Email;

public class EmailRequestBody
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
        
    [Required]
    public string Subject { get; set; }
        
    [Required]
    public string Body { get; set; }
}