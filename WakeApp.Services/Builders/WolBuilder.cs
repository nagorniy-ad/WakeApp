using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace WakeApp.Services
{
    public class WolBuilder
    {
        private const int DEFAULT_PORT = 9;
        private readonly UdpClient _udp;
        private readonly PhysicalAddress _macAddress;
        private IPAddress _ipAddress;
        private IPAddress _subnetMask;
        private int _port;

        public WolBuilder(IPAddress localIpAddress, int localPort, PhysicalAddress remoteMacAddress)
        {
            if (localIpAddress == null)
            {
                throw new ArgumentNullException(nameof(localIpAddress));
            }
            if (localPort <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(localPort));
            }

            _udp = new UdpClient(localEP: new IPEndPoint(address: localIpAddress, port: localPort));
            _macAddress = remoteMacAddress ?? throw new ArgumentNullException(nameof(remoteMacAddress));
            _port = DEFAULT_PORT;
        }

        public static WolBuilder Create(IPAddress localIpAddress, int localPort, PhysicalAddress remoteMacAddress)
        {
            return new WolBuilder(localIpAddress, localPort, remoteMacAddress);
        }

        public WolBuilder SetIpAddress(IPAddress ipAddress)
        {
            _ipAddress = ipAddress ?? throw new ArgumentNullException(nameof(ipAddress));
            return this;
        }

        public WolBuilder SetSubnetMask(IPAddress subnetMask)
        {
            _subnetMask = subnetMask ?? throw new ArgumentNullException(nameof(subnetMask));
            return this;
        }

        public WolBuilder SetPort(int port)
        {
            _port = (port > 0) ? port : throw new ArgumentOutOfRangeException(nameof(port));
            return this;
        }

        public async Task WakeUpAsync()
        {
            using (_udp)
            {
                var magicPacket = CreateMagicPacketContent();
                var endPoint = (_ipAddress != null && _subnetMask != null) ?
                    new IPEndPoint(address: GetBroadcastAddressByIpAddress(), port: _port) :
                    new IPEndPoint(address: IPAddress.Broadcast, port: _port);
                await _udp.SendAsync(datagram: magicPacket, bytes: magicPacket.Length, endPoint: endPoint);
            }
        }

        #region private

        private byte[] CreateMagicPacketContent()
        {
            using (var memoryStream = new MemoryStream())
            {
                byte[] syncStream = { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                memoryStream.Write(buffer: syncStream, offset: 0, count: syncStream.Length);
                byte[] macAddress = _macAddress.GetAddressBytes();
                for (int i = 0; i < 16; i++)
                {
                    memoryStream.Write(buffer: macAddress, offset: 0, count: macAddress.Length);
                }
                return memoryStream.ToArray();
            }
        }

        private IPAddress GetBroadcastAddressByIpAddress()
        {
            var address = BitConverter.ToInt32(value: _ipAddress.GetAddressBytes(), startIndex: 0);
            var subnetMask = BitConverter.ToInt32(value: _subnetMask.GetAddressBytes(), startIndex: 0);
            var broadcastAddress = address | ~subnetMask;
            return new IPAddress(address: BitConverter.GetBytes(broadcastAddress));
        }

        #endregion
    }
}
