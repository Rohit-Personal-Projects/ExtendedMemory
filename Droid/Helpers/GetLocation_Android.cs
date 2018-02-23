using ExtendedMemory.Models;
using ExtendedMemory.Helpers;
using ExtendedMemory.Android.Helpers;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(GetLocation_Android))]
namespace ExtendedMemory.Android.Helpers
{
    public class GetLocation_Android : IGetLocation
    {
        public GetLocation_Android() {}

        public void GetUserLocation(Entry entryCity, Entry entryState, Entry entryCountry){}

        public Location GetUserLocation()
        {
            return null;
            //return new Location
            //{
            //    City = "Android Bloo"
            //};
        }
    }
}
