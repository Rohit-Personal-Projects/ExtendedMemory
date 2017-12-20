using ExtendedMemory.Models;
using ExtendedMemory.Helpers;
using ExtendedMemory.iOS.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(GetLocation_IOS))]
namespace ExtendedMemory.iOS.Helpers
{
    public class GetLocation_IOS : IGetLocation
    {
        public GetLocation_IOS() {}

        public Location GetUserLocation()
        {
            return new Location
            {
                City = "IOS Bloo"
            };
        }
    }
}
