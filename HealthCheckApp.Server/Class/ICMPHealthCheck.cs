using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.NetworkInformation;

namespace HealthCheckApp.Server.Class
{
    public class ICMPHealthCheck : IHealthCheck
    {
        private readonly string Host;
        private readonly int HealthyRoundtripTime;

        public ICMPHealthCheck( string host, int healthyRoundTripTime)
        {
            Host = host;
            HealthyRoundtripTime = healthyRoundTripTime;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                using var ping = new Ping();
                var reply = await ping.SendPingAsync(Host);

                switch (reply.Status)
                {
                    case IPStatus.Success:
                        var msg = $"ICMP to {Host} took {reply.RoundtripTime} ms.";

                        return (reply.RoundtripTime > HealthyRoundtripTime)
                            ? HealthCheckResult.Degraded(msg)
                            : HealthCheckResult.Healthy(msg);

                    default:
                        var err = $"ICMP to {Host} failed: {reply.Status}";
                        return HealthCheckResult.Unhealthy(err);
                }
            }
            catch (Exception ex)
            {
                var err = $"ICMP failed: {ex.Message}";
                return HealthCheckResult.Unhealthy(err);
            }
        }
    }
}
