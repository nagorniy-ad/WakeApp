using System;
using System.Threading.Tasks;
using WakeApp.Core;

namespace WakeApp.Services
{
    public class WolService : IWolService
    {
        private readonly ILocalEndPoint _localEndPoint;

        public WolService(ILocalEndPoint localEndPoint)
        {
            _localEndPoint = localEndPoint ?? throw new ArgumentNullException(nameof(localEndPoint));
        }

        public async Task WakeUpAsync(IRemoteEndPoint remoteEndPoint)
        {
            if (remoteEndPoint == null)
            {
                throw new ArgumentNullException(nameof(remoteEndPoint));
            }
            if (remoteEndPoint.MacAddress == null)
            {
                throw new ArgumentException(
                    message: "MAC-адрес не задан.",
                    paramName: nameof(remoteEndPoint));
            }

            if (_localEndPoint.IpAddress == null)
            {
                throw new InvalidOperationException("IP-адрес локальной конечной точки не задан.");
            }
            if (_localEndPoint.Port == null)
            {
                throw new InvalidOperationException("Порт локальной конечной точки не задан.");
            }
            if (_localEndPoint.Port <= 0)
            {
                throw new InvalidOperationException("Порт локальной конечной точки некорректен.");
            }
            if (remoteEndPoint.IpAddress != null && remoteEndPoint.SubnetMask != null)
            {
                await WolBuilder.Create(_localEndPoint.IpAddress, _localEndPoint.Port.Value, remoteEndPoint.MacAddress)
                    .SetIpAddress(remoteEndPoint.IpAddress)
                    .SetSubnetMask(remoteEndPoint.SubnetMask)
                    .WakeUpAsync();
            }
            else
            {
                await WolBuilder.Create(_localEndPoint.IpAddress, _localEndPoint.Port.Value, remoteEndPoint.MacAddress)
                    .WakeUpAsync();
            }
        }
    }
}
