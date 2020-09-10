using Microsoft.Extensions.Configuration;
using System.Net;
using WakeApp.Core;

namespace WakeApp.Web.Extensions
{
    public static class ConfigurationExtensions
    {
        public static ILocalEndPoint GetLocalEndPoint(this IConfiguration configuration)
        {
            var localEndPointSection = configuration.GetSection("LocalEndPoint");
            IPAddress ipAddress = null;
            int? port = null;
            if (string.IsNullOrWhiteSpace(localEndPointSection["IpAddress"]) == false && IPAddress.TryParse(localEndPointSection["IpAddress"], out IPAddress parsedIpAddress) == true)
            {
                ipAddress = parsedIpAddress;
            }
            if (string.IsNullOrWhiteSpace(localEndPointSection["Port"]) == false && int.TryParse(localEndPointSection["Port"], out int parsedPort) == true)
            {
                port = parsedPort;
            }
            return new LocalEndPoint(ipAddress, port);
        }
    }
}
