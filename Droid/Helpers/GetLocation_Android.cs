using ExtendedMemory.Models;
using ExtendedMemory.Helpers;
using ExtendedMemory.Android.Helpers;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(GetLocation_Android))]
namespace ExtendedMemory.Android.Helpers
{
    public class GetLocation_Android : IGetLocation
    {
        public GetLocation_Android() {}

        public Task<Location> GetUserLocation()
        {
            return null;
            //return new Location
            //{
            //    City = "Android Bloo"
            //};
        }
    }
}
