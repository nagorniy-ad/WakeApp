using System.Net;
using System.Net.NetworkInformation;
using WakeApp.Core;

namespace WakeApp.Web
{
    public class RemoteEndPoint : IRemoteEndPoint
    {
        public PhysicalAddress MacAddress { get; }
        public IPAddress IpAddress { get; }
        public IPAddress SubnetMask { get; }

        public RemoteEndPoint(PhysicalAddress macAddress)
        {
            MacAddress = macAddress;
        }

        public RemoteEndPoint(PhysicalAddress macAddress, IPAddress ipAddress, IPAddress subnetMask)
        {
            MacAddress = macAddress;
            IpAddress = ipAddress;
            SubnetMask = subnetMask;
        }
    }
}
