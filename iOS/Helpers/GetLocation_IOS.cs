using ExtendedMemory.Models;
using ExtendedMemory.Helpers;
using ExtendedMemory.iOS.Helpers;
using CoreLocation;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(GetLocation_IOS))]
namespace ExtendedMemory.iOS.Helpers
{
    public class GetLocation_IOS : IGetLocation
    {
        //CLPlacemark[] userAddress = null;
        CLLocationManager locationManager;

        public GetLocation_IOS() {
            

            //try
            //{


                

            //}catch(Exception ex){
            //    Console.WriteLine(ex.Message);
            //}
        }

        //void LocationManager_LocationsUpdated(object sender, CLLocationsUpdatedEventArgs e)
        //{
        //    e.Locations[0].Coordinate.
        //}

        public void GetUserLocation(Entry entryCity, Entry entryState, Entry entryCountry)
        {
            try
            {
                locationManager = new CLLocationManager();
                locationManager.RequestWhenInUseAuthorization();



                //Device.BeginInvokeOnMainThread();

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
                    //var userAddress = await new CLGeocoder().ReverseGeocodeLocationAsync(location);

                    //foreach (var pp in userAddress)
                    //{
                    //    entryCity.Text = pp.Locality;
                    //    entryState.Text = pp.AdministrativeArea;
                    //    entryCountry.Text = pp.Country;
                    //}

                    //locationManager.StopUpdatingLocation();();
                };

                locationManager.StartUpdatingLocation();

                Task.Delay(3000).Wait();

                //var geoCoder = new CLGeocoder();

                //Console.WriteLine("start");
                //var userAddress = await new CLGeocoder().ReverseGeocodeLocationAsync(locationManager.Location);
                //foreach(var pp in userAddress) {
                //    Console.WriteLine("name = " + pp.Name);
                //}

                //return userAddress == null ? null : new Location
                //{
                //    Street = userAddress[0].Name,
                //    City = userAddress[0].Locality,
                //    State = "in",
                //    Country = userAddress[0].Country,
                //    Latitude = userAddress[0].Location.Coordinate.Latitude,
                //    Longitude = userAddress[0].Location.Coordinate.Longitude
                //};


                //CLPlacemark p = null;
                //geoCoder.ReverseGeocodeLocation(locationManager.Location, (placemarks, error) => {
                //    Console.WriteLine("in");
                //    p = placemarks[0];
                //    //location.State = placemarks[0].
                //});
                //geoCoder.

                //location = new Location();
                //Console.WriteLine("end");
                //location.Country = p?.Country;

                //Console.WriteLine("end2");


                ////foreach (var placemark in userAddress) {
                ////      Console.WriteLine(placemark);
                ////} 

                //location.Street = locationManager.Location.Coordinate.Latitude.ToString();
                //location.City = "cittyyy";
                ////location = new Location
                ////{
                ////    Street = locationManager.Location.Coordinate.Latitude.ToString(),
                ////    City = "IOS Bloo"
                ////};
                //return null;
            }catch(Exception e){
                Console.WriteLine("Bad : " + e);
                return;
            }


            //locationManager.Delegate = 

            //locationManager.StartUpdatingLocation();
            ////locationManager.StartUpdatingHeading();

            //locationManager.LocationsUpdated += delegate (object sender, CLLocationsUpdatedEventArgs e)
            //{
            //    foreach (CLLocation loc in e.Locations)
            //    {
            //        Console.WriteLine(loc.Coordinate.Latitude);
            //    }
            //};



            //Console.WriteLine(locationManager.Location.Coordinate);



            //return new Location
            //{
            //    City = "IOS Bloo"
            //};


            //locationManager.StartUpdatingLocation();
            //locationManager.StartUpdatingHeading();

            //locationManager.LocationsUpdated += delegate (object sender, CLLocationsUpdatedEventArgs e)
            //{
            //    foreach (CLLocation loc in e.Locations)
            //    {
            //        Console.WriteLine(loc.Coordinate.Latitude);
            //    }
            //};


            ////var locationCoordinates = new CLLocationManager().Location.Coordinate;

            //var LocMgr = new CLLocationManager();
            //LocMgr.RequestWhenInUseAuthorization();

            ////if (!CLLocationManager.LocationServicesEnabled)
            ////{
            ////    return null;
            ////}

            //if (IsAuthorized())
            //{
            //    CLLocation _currentLocation;

            //    Console.WriteLine("start1");

            //    //set the desired accuracy, in meters
            //    LocMgr.DesiredAccuracy = 1;
            //    LocMgr.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) =>
            //    {
            //        _currentLocation = (e.Locations[e.Locations.Length - 1]);
            //        Console.WriteLine(_currentLocation.Coordinate);
            //    };

            //    Console.WriteLine("start2 ");

            //    LocMgr.AuthorizationChanged += (object sender, CLAuthorizationChangedEventArgs e) =>
            //    {
            //        if (e.Status == CLAuthorizationStatus.Denied || e.Status == CLAuthorizationStatus.Restricted)
            //        {
            //            LocMgr.StopUpdatingLocation();
            //            _currentLocation = null;
            //        }
            //    };
            //    Console.WriteLine("start3");

            //    LocMgr.StartUpdatingLocation();

            //    if(_currentLocation != null)
            //    {
            //        return new Location
            //        {
            //            City = "IOS Bloo"
            //        };
            //    }
            //}

            //return null;




        }

        //private bool IsAuthorized()
        //{
        //    return CLLocationManager.Status == CLAuthorizationStatus.AuthorizedAlways || CLLocationManager.Status == CLAuthorizationStatus.AuthorizedWhenInUse;
        //}
    }
}
