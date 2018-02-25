using System;
using System.IO;
using ExtendedMemory.Helpers;
using Xamarin.Forms;

namespace ExtendedMemory.Views
{
    public partial class HomePage : ContentPage
    {

        public HomePage()
        {
            InitializeComponent();

            time.Time = DateTime.Now.TimeOfDay;
            DependencyService.Get<IGetLocation>().GetUserLocation(entryCity, entryState, entryCountry);
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

                // /Users/rohit/Library/Developer/CoreSimulator/Devices/45163EF8-B7EB-4321-877C-F8CAA9B5D484/data/Containers/Data/Application/77BFD79E-8A35-436C-B8F2-1E5CB1D047B1/Documents
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string filePath = Path.Combine(path, "out.txt");

                File.AppendAllText(filePath, $"{txtEntry.Text}#{date.Date + time.Time}#{entryCity.Text}#{entryState.Text}#{entryCountry.Text}\n");
                Console.WriteLine($"{txtEntry.Text}#{date.Date + time.Time}#{entryCity.Text}#{entryState.Text}#{entryCountry.Text}\n");

                //string text = File.ReadAllText(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
