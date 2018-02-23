using ExtendedMemory.Android.Helpers;
using ExtendedMemory.Helpers;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(GetLocation_Android))]
namespace ExtendedMemory.Android.Helpers
{
    public class GetLocation_Android : IGetLocation
    {
        public void GetUserLocation(Entry entryCity, Entry entryState, Entry entryCountry)
        {}
    }
}
