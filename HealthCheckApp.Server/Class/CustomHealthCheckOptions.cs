using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Net.Mime;
using System.Text.Json;

namespace HealthCheckApp.Server.Class
{
    public class CustomHealthCheckOptions : HealthCheckOptions
    {
        public CustomHealthCheckOptions() : base()
        {
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };
            ResponseWriter = async (c, r) =>
            {
                c.Response.ContentType = MediaTypeNames.Application.Json;
                c.Response.StatusCode = StatusCodes.Status200OK;

                var result = JsonSerializer.Serialize(new
                {
                    checks = r.Entries.Select(s => new
                    {
                        name = s.Key,
                        responseTime = s.Value.Duration.TotalMilliseconds,
                        status = s.Value.Status.ToString(),
                        description = s.Value.Description,
                    }),
                    totalStatus = r.Status,
                    totalResponceTime = r.TotalDuration.TotalMilliseconds
                }, jsonSerializerOptions);
                await c.Response.WriteAsync(result);
            };
        }
    }
}
