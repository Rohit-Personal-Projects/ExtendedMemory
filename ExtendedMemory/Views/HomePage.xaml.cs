using System;
using System.Linq;
using ExtendedMemory.DataAccess;
using ExtendedMemory.Helpers;
using ExtendedMemory.Models;
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

                var memory = new Memory
                {
                    Text = txtEntry.Text,
                    Date = date.Date + time.Time,
                    City = entryCity.Text,
                    State = entryState.Text,
                    Country = entryCountry.Text,
                    People = txtPeople.Text.Split(' ').ToList(),
                    Tags = txtTags.Text.Split(' ').ToList(),
                };

                Console.WriteLine(memory);

                //var memoryDB = DependencyService.Get<IMemoryDatabase>();
                //memoryDB.Save(memory);
                //var test = memoryDB.Get();

                await DisplayAlert("Success", "Memory saved.", "OK");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
