using System.Threading.Tasks;
using ExtendedMemory.Models;

namespace ExtendedMemory.Helpers
{
    public interface IGetLocation
    {
        Task<Location> GetUserLocation();
    }
}
