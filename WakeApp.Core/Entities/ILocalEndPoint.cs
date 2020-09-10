using System.Net;

namespace WakeApp.Core
{
    public interface ILocalEndPoint
    {
        IPAddress IpAddress { get; }
        int? Port { get; }
    }
}
