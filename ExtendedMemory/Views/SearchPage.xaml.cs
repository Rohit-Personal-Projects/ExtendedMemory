using System;
using System.Linq;
using System.Threading.Tasks;
using ExtendedMemory.DataAccess;
using ExtendedMemory.Models;
using Xamarin.Forms;

namespace ExtendedMemory.Views
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();

            var dds = new Picker[] { ddSearchByPeople, ddSearchByTag, ddSearchByCity, ddSearchByState, ddSearchByCountry };
            foreach (var dd in dds)
            {
                dd.Items.Add("");
                dd.SelectedIndexChanged += (sender, e) => AppendToTextField(txtSearchByTag, dd.SelectedItem.ToString());
            }

            Task.Run(async () => { 
                var a23 = await DependencyService.Get<IMemoryDatabase>().Get();

                ddSearchByPeople.Items.Add("Niki_Async");
                ddSearchByPeople.Items.Add("Niki");
                ddSearchByPeople.Items.Add("Sumit");

                ddSearchByTag.Items.Add("Swim");
                ddSearchByTag.Items.Add("PS4");
            }).Wait();
        }

        private void AppendToTextField(Entry entry, string text)
        {
            entry.Text += (String.IsNullOrWhiteSpace(entry.Text) ? "" : ", ") + text;
        }

        async void SearchMemory(object sender, EventArgs args)
        {
            try
            {
                Button button = (Button)sender;

                var a = ddSearchByPeople.SelectedItem?.ToString();

                //if nothin to search
                //if (String.IsNullOrWhiteSpace(txtEntry.Text))
                //{
                //    await DisplayAlert("Enter Text", "Please enter some text", "OK");
                //    return;
                //}

                SearchParams obj = new SearchParams()
                {
                    FromDate = dtSearchByDateFrom,
                    ToDate = dtSearchByDateTo,
                    FromTime = tmSearchByTimeFrom,
                    ToTime = tmSearchByTimeTo,
                    Location = new Location()
                    {
                        City = ddSearchByCity.Items[ddSearchByCity.SelectedIndex],
                        State = ddSearchByState.Items[ddSearchByState.SelectedIndex],
                        Country = ddSearchByCountry.Items[ddSearchByCountry.SelectedIndex],
                    },
                    Memory = txtSearchByMemory.Text.Split(' ').ToList(),
                    People = txtSearchByPeople.Text.Split(' ').ToList(),
                    Tags = txtSearchByTag.Text.Split(' ').ToList(),

                };
                //App.Current.MainPage = new SearchResultsPage();
                //App.Current.MainPage.Navigation.PushAsync(new SearchResultsPage());

                await DisplayAlert("Success", "Memory search complete.", "OK");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}