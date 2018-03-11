using System;
using System.Collections.Generic;
using System.Linq;
using Couchbase.Lite;
using ExtendedMemory.DataAccess;
using ExtendedMemory.Helpers;
using ExtendedMemory.Models;
using Xamarin.Forms;


namespace ExtendedMemory.Views
{
    public partial class SavePage : ContentPage
    {
        public SavePage()
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
                    People = txtPeople.Text.Split(' ').ToList(),
                    Tags = txtTags.Text.Split(' ').ToList(),
                    DateTime = date.Date + time.Time,
                    Location = new Location
                    {
                        City = entryCity.Text,
                        State = entryState.Text,
                        Country = entryCountry.Text
                    }
                };

                var saveResponse = DependencyService.Get<IMemoryDatabase>().Save(memory);

                if (saveResponse.IsSuccess)
                {
                    // Diplay document id only for testing purposes.
                    await DisplayAlert("Success", "Memory saved " + saveResponse.Item, "OK");
                }
                else
                {
                    await DisplayAlert("Fail!", "Memory not saved.", "OK");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
