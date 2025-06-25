using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Medical.Office.Net8WebApi.HealthChecks;

public class MemoryHealthCheck : IHealthCheck
{
    private readonly long _maxMemoryThreshold;

    public MemoryHealthCheck(long maxMemoryThreshold)
    {
        _maxMemoryThreshold = maxMemoryThreshold;
    }

    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        var allocatedMemory = GC.GetTotalMemory(false);
        var allocatedMemoryMB = allocatedMemory / 1024 / 1024;

        var data = new Dictionary<string, object>
        {
            { "Memoria asignada (MB)", allocatedMemoryMB },
            { "Umbral máximo (MB)", _maxMemoryThreshold }
        };

        return Task.FromResult(allocatedMemoryMB < _maxMemoryThreshold
            ? HealthCheckResult.Healthy("La memoria asignada está dentro de los límites.", data)
            : HealthCheckResult.Unhealthy("La memoria asignada supera el umbral permitido.", data: data));
    }
}