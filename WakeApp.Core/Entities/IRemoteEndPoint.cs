using System.Net;
using System.Net.NetworkInformation;

namespace WakeApp.Core
{
    public interface IRemoteEndPoint
    {
        PhysicalAddress MacAddress { get; }
        IPAddress IpAddress { get; }
        IPAddress SubnetMask { get; }
    }
}
