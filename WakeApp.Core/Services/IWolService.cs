using System.Threading.Tasks;

namespace WakeApp.Core
{
    public interface IWolService
    {
        Task WakeUpAsync(IRemoteEndPoint remoteEndPoint);
    }
}
