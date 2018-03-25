using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExtendedMemory.DataAccess;
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

            Task.Run(async () => 
            { 
                var memories = await DependencyService.Get<IMemoryDatabase>().Get();
                if (!memories.IsSuccess)
                {
                    // local log
                }
                else
                {
                    var peopleMap = new Dictionary<string, int>();
                    var tagsMap = new Dictionary<string, int>();
                    var cityMap = new Dictionary<string, int>();
                    var stateMap = new Dictionary<string, int>();
                    var countryMap = new Dictionary<string, int>();

                    memories.Item.ForEach(memory =>
                    {
                        memory.People.ForEach(v => AddByCount(v, peopleMap));
                        memory.Tags.ForEach(v => AddByCount(v, tagsMap));
                        if (memory.Location != null)
                        {
                            AddByCount(memory.Location.City, cityMap);
                            AddByCount(memory.Location.State, stateMap);
                            AddByCount(memory.Location.Country, countryMap);
                        }
                    });

                    PopulateDropdown(ddSearchByPeople.Items, peopleMap);
                    PopulateDropdown(ddSearchByTag.Items, tagsMap);
                    PopulateDropdown(ddSearchByCity.Items, cityMap);
                    PopulateDropdown(ddSearchByState.Items, stateMap);
                    PopulateDropdown(ddSearchByCountry.Items, countryMap);
                }
            }).Wait();
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

                await DisplayAlert("Success", "Memory search complete.", "OK");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void PopulateDropdown(IList<string> dropdownItems, Dictionary<string, int> itemDict)
        {
            foreach (var item in itemDict.OrderByDescending(p => p.Value))
            {
                dropdownItems.Add(item.Key);
            }
        }

        private void AddByCount(string value, Dictionary<string, int> itemDict)
        {
            if (!String.IsNullOrWhiteSpace(value))
            {
                itemDict.TryGetValue(value, out var count);
                itemDict[value] = count + 1;
            }
        }

        private void AppendToTextField(Entry entry, string text)
        {
            entry.Text += (String.IsNullOrWhiteSpace(entry.Text) ? "" : ", ") + text;
        }
    }
}