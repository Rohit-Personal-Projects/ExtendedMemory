using System;
using CoreLocation;
using ExtendedMemory.Helpers;
using ExtendedMemory.iOS.Helpers;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(GetLocation_IOS))]
namespace ExtendedMemory.iOS.Helpers
{
    public class GetLocation_IOS : IGetLocation
    {
        CLLocationManager locationManager;

        public void GetUserLocation(Entry entryCity, Entry entryState, Entry entryCountry)
        {
            try
            {
                locationManager = new CLLocationManager();
                locationManager.RequestWhenInUseAuthorization();

                locationManager.LocationsUpdated += (sender, e) =>
                {
                    // Last item in the array is the latest location
                    var location = e.Locations[e.Locations.Length - 1];
                    new CLGeocoder().ReverseGeocodeLocation(location, (placemarks, error) =>
                    {
                        foreach (var pp in placemarks)
                        {
                            entryCity.Text = pp.Locality;
                            entryState.Text = pp.AdministrativeArea;
                            entryCountry.Text = pp.Country;
                        }
                    });
                };

                locationManager.StartUpdatingLocation();
            }
            catch (Exception e)
            {
                Console.WriteLine("Bad : " + e);
                return;
            }
        }
    }
}
