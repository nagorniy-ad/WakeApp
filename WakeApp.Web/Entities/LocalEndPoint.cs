using System.Net;
using WakeApp.Core;

namespace WakeApp.Web
{
    public class LocalEndPoint : ILocalEndPoint
    {
        public IPAddress IpAddress { get; }
        public int? Port { get; }

        public LocalEndPoint() { }

        public LocalEndPoint(IPAddress ipAddress, int? port)
        {
            IpAddress = ipAddress;
            Port = port;
        }
    }
}
