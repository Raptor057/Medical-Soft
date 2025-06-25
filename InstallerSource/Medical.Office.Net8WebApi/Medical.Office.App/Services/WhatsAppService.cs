using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Medical.Office.App.Services;

public class WhatsAppService
{
    private readonly HttpClient _httpClient;
    private readonly string _accessToken;
    private readonly string _phoneNumberId;

    public WhatsAppService(IConfiguration configuration)
    {
        _httpClient = new HttpClient();
        _accessToken = configuration["WhatsApp:AccessToken"];
        _phoneNumberId = configuration["WhatsApp:PhoneNumberId"];
    }

    public async Task<bool> SendMessageAsync(string to, string templateName, string languageCode)
    {
        var url = $"https://graph.facebook.com/v21.0/{_phoneNumberId}/messages";
            
        var payload = new
        {
            messaging_product = "whatsapp",
            to = to,
            type = "template",
            template = new
            {
                name = templateName,
                language = new { code = languageCode }
            }
        };
            
        var requestContent = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_accessToken}");
            
        var response = await _httpClient.PostAsync(url, requestContent);
        return response.IsSuccessStatusCode;
    }
}