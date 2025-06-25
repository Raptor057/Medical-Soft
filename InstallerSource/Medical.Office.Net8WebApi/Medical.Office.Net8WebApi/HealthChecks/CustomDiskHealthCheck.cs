using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Medical.Office.Net8WebApi.HealthChecks;

public class CustomDiskHealthCheck : IHealthCheck
{
    private readonly string _driveName;
    private readonly long _minFreeMegabytes;

    public CustomDiskHealthCheck(string driveName, long minFreeMegabytes)
    {
        _driveName = driveName;
        _minFreeMegabytes = minFreeMegabytes;
    }

    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        var drive = new DriveInfo(_driveName);
        var freeSpaceMB = drive.AvailableFreeSpace / 1024 / 1024;

        var data = new Dictionary<string, object>
        {
            { "Espacio libre en disco (MB)", freeSpaceMB },
            { "Umbral mínimo (MB)", _minFreeMegabytes }
        };

        return Task.FromResult(freeSpaceMB > _minFreeMegabytes
            ? HealthCheckResult.Healthy("El espacio en disco es adecuado.", data)
            : HealthCheckResult.Unhealthy("El espacio en disco es insuficiente.", data: data));
    }
}