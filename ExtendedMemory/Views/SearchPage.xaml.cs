using System;
using System.Collections.Generic;
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

            tmSearchByTimeTo.Time = new TimeSpan(23, 59, 59);
            dtSearchByDateFrom.Date = new DateTime(1900, 1, 1);
            InitializeDropdowns();

            Task.Run(async () => 
            {
                var memories = await new MemoryDatabase().Get();
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

        void SearchMemory(object sender, EventArgs args)
        {
            try
            {
                Button button = (Button)sender;

                var searchParams = new SearchParams()
                {
                    Memory = !String.IsNullOrWhiteSpace(txtSearchByMemory.Text) ? txtSearchByMemory.Text.Split(' ').ToList() : null,
                    People = !String.IsNullOrWhiteSpace(txtSearchByPeople.Text) ? txtSearchByPeople.Text.Split(' ').ToList() : null,
                    Tags = !String.IsNullOrWhiteSpace(txtSearchByTag.Text) ? txtSearchByTag.Text.Split(' ').ToList() : null,
                    Location = new Location()
                    {
                        City = ddSearchByCity.SelectedIndex != -1 ? ddSearchByCity.Items[ddSearchByCity.SelectedIndex]: "",
                        State = ddSearchByState.SelectedIndex != -1 ? ddSearchByState.Items[ddSearchByState.SelectedIndex]: "",
                        Country = ddSearchByCountry.SelectedIndex != -1 ? ddSearchByCountry.Items[ddSearchByCountry.SelectedIndex] : "",
                    },
                    FromDate = dtSearchByDateFrom.Date,
                    ToDate = dtSearchByDateTo.Date.AddDays(1),
                    FromTime = tmSearchByTimeFrom.Time,
                    ToTime = tmSearchByTimeTo.Time
                };

                Application.Current.MainPage = new SearchResultsPage(searchParams);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void InitializeDropdowns()
        {
            var dds = new Dictionary<Picker, Entry>()
            {
                { ddSearchByPeople, txtSearchByPeople },
                { ddSearchByTag, txtSearchByTag },
                { ddSearchByCity, null },
                { ddSearchByState, null },
                { ddSearchByCountry, null },
            };

            foreach (var dd in dds)
            {
                dd.Key.Items.Add("");
                if (dd.Value != null)
                {
                    dd.Key.SelectedIndexChanged += (sender, e) => AppendToTextField(dd.Value, dd.Key.SelectedItem.ToString());
                }
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