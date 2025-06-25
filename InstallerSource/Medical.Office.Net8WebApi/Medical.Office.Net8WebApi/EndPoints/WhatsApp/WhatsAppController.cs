using Medical.Office.App.Services;
using Medical.Office.App.UseCases.WhatsApp;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.WhatsApp;

[Route("[controller]")]
[ApiController]
public class WhatsAppController : ControllerBase
{
    private readonly ILogger<WhatsAppController> _logger;
    private readonly WhatsAppService _whatsAppService;

    public WhatsAppController(ILogger<WhatsAppController> logger, WhatsAppService whatsAppService)
    {
        _logger = logger;
        _whatsAppService = whatsAppService;
    }

    [HttpPost]
    [Route("/api/whatsapp/send")]
    public async Task<IActionResult> SendMessage([FromBody] WhatsAppRequest request)
    {
        try
        {
            bool isSent = await _whatsAppService.SendMessageAsync(request.To, request.TemplateName, request.LanguageCode);
                
            if (isSent)
            {
                return Ok(new { success = true, message = "Mensaje enviado exitosamente." });
            }
            else
            {
                return StatusCode(500, new { success = false, message = "Error enviando el mensaje." });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error enviando mensaje: {ex.Message}");
            return StatusCode(500, new { success = false, message = ex.Message });
        }
    }
}