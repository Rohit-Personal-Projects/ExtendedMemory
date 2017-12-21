using ExtendedMemory.Models;
using System;
using System.IO;
using Xamarin.Forms;
using ExtendedMemory.Helpers;
using Xamarin.Forms.Maps;

namespace ExtendedMemory.Views
{
    public partial class HomePage : ContentPage
    {
        Location userLocation;
        Geocoder geoCoder;

        public HomePage()
        {
            InitializeComponent();
            time.Time = DateTime.Now.TimeOfDay;
            geoCoder = new Geocoder();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            try
            {
                Button button = (Button)sender;

                if (String.IsNullOrWhiteSpace(txtEntry.Text))
                {
                    await DisplayAlert("Enter Text", "Please enter some text", "OK");
                    return;
                }

                userLocation = DependencyService.Get<IGetLocation>().GetUserLocation();

                var position = new Position(39, -86);
                Xamarin.FormsMaps.Init();
                var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
                foreach (var address in possibleAddresses)
                {
                    Console.WriteLine(address);
                    txtEntry.Text = "boo " + address;
                }

                Console.WriteLine(userLocation.City);

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

                File.AppendAllText(filePath, $"{txtEntry.Text}#{date.Date + time.Time}\n");


                //string text = File.ReadAllText(filePath);
                //Console.WriteLine(text);
            }catch(Exception e){
                Console.WriteLine(e);
            }
        }
    }
}
