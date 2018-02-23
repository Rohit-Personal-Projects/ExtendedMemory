using ExtendedMemory.Models;
using System;
using System.IO;
using Xamarin.Forms;
using ExtendedMemory.Helpers;
//using Xamarin.Forms.Maps;
using System.Threading.Tasks;

namespace ExtendedMemory.Views
{
    public partial class HomePage : ContentPage
    {
        //Location userLocation;
        //Geocoder geoCoder;

        void UpdateAddress()
        {
            //DependencyService.Get<IGetLocation>().GetUserLocation(entryCity, entryState, entryCountry);
            //Location userLocation = DependencyService.Get<IGetLocation>().GetUserLocation(entryCity, entryState, entryCountry);
            //if (userLocation != null)
            //{
            //    if (!String.IsNullOrWhiteSpace(userLocation.City) && !String.Equals(entryCity.Text, "City"))
            //    {
            //        entryCity.Text = userLocation.City;
            //    }
            //    if (!String.IsNullOrWhiteSpace(userLocation.State) && !String.Equals(entryState.Text, "State"))
            //    {
            //        entryState.Text = userLocation.State;
            //    }
            //    if (!String.IsNullOrWhiteSpace(userLocation.Country) && !String.Equals(entryCountry.Text, "Country"))
            //    {
            //        entryCountry.Text = userLocation.Country;
            //    }
            //}
        }

        public HomePage()
        {
            InitializeComponent();
            time.Time = DateTime.Now.TimeOfDay;

            DependencyService.Get<IGetLocation>().GetUserLocation(entryCity, entryState, entryCountry);

            //Task.Run(async () =>
            //{
            //    var location = await DependencyService.Get<IGetLocation>().GetUserLocation(entryCity, entryState, entryCountry);
            //});

            //UpdateAddress();
            //DependencyService.Get<IGetLocation>().GetUserLocation(entryCity, entryState, entryCountry);

            //geoCoder = new Geocoder();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            Console.WriteLine("but");
            try
            {
                Button button = (Button)sender;

                if (String.IsNullOrWhiteSpace(txtEntry.Text))
                {
                    await DisplayAlert("Enter Text", "Please enter some text", "OK");
                    return;
                }

                //userLocation = DependencyService.Get<IGetLocation>().GetUserLocation().Result;

                //var position = new Position(39, -86);
                //Xamarin.FormsMaps.Init();
                //var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
                //foreach (var address in possibleAddresses)
                //{
                //    Console.WriteLine(address);
                //    txtEntry.Text = "boo " + address;
                //}

                //Console.WriteLine(userLocation.City);

                //Location userLocation = IGetLocation();

                //if (!CLLocationManager.LocationServicesEnabled)
                //{
                //    await DisplayAlert("Enable Location", "", "OK");
                //    return;
                //}

                //var locationManager = new CLLocationManager();
                //Console.WriteLine(locationManager.Location.Coordinate);

                /*var position = new Position(locationManager.Location.Coordinate.Latitude, locationManager.Location.Coordinate.Longitude);
                var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
                foreach (var address in possibleAddresses)
                {
                    Console.WriteLine(address);
                }*/



                // /Users/rohit/Library/Developer/CoreSimulator/Devices/45163EF8-B7EB-4321-877C-F8CAA9B5D484/data/Containers/Data/Application/77BFD79E-8A35-436C-B8F2-1E5CB1D047B1/Documents
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string filePath = Path.Combine(path, "out.txt");

                File.AppendAllText(filePath, $"{txtEntry.Text}#{date.Date + time.Time}#{entryCity.Text}#{entryState.Text}#{entryCountry.Text}\n");
                Console.WriteLine($"{txtEntry.Text}#{date.Date + time.Time}#{entryCity.Text}#{entryState.Text}#{entryCountry.Text}\n");
                Console.WriteLine(path);


                //string text = File.ReadAllText(filePath);
                //Console.WriteLine(text);
            }catch(Exception e){
                Console.WriteLine(e);
            }
        }
    }
}
