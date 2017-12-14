using ExtendedMemory.Models;
using ExtendedMemory.Helpers;
using ExtendedMemory.Android.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(GetLocation_Android))]
namespace ExtendedMemory.Android.Helpers
{
    public class GetLocation_Android : IGetLocation
    {
        public GetLocation_Android() {}

        public Location GetUserLocation()
        {
            return new Location
            {
                City = "Android Bloo"
            };
        }
    }
}
