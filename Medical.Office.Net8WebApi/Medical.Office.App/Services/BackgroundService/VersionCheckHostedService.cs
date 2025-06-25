using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace Medical.Office.App.Services.BackgroundService
{
    public class VersionCheckHostedService : IHostedService
    {
        private readonly ILogger<VersionCheckHostedService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private Timer? _timer;

        private readonly string _localVersionPath = Path.Combine(AppContext.BaseDirectory, "version");
        private const string _remoteVersionUrl = "https://raw.githubusercontent.com/Raptor057/Medical.Office.Net8WebApi/refs/heads/main/Medical.Office.Net8WebApi/version";

        public VersionCheckHostedService(ILogger<VersionCheckHostedService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("🔁 Servicio de verificación de versión iniciado.");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1)); // cada 5 minutos
            return Task.CompletedTask;
        }

        private async void DoWork(object? state)
        {
            try
            {
                string? localVersion = null;
                if (File.Exists(_localVersionPath))
                    localVersion = File.ReadAllText(_localVersionPath).Trim();

                var httpClient = _httpClientFactory.CreateClient();
                var remoteVersion = (await httpClient.GetStringAsync(_remoteVersionUrl)).Trim();

                if (!string.IsNullOrEmpty(localVersion) && !string.IsNullOrEmpty(remoteVersion))
                {
                    if (localVersion != remoteVersion)
                    {
                        _logger.LogWarning("⚠️ Hay una nueva versión disponible: local={local}, remota={remote}", localVersion, remoteVersion);
                        // Aquí puedes mandar email, webhook, etc.
                    }
                    else
                    {
                        _logger.LogInformation("✅ La versión local está actualizada: {version}", localVersion);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error al comparar versiones.");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("⏹️ Servicio de verificación de versión detenido.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
