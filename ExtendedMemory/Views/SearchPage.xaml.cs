using System;
using ExtendedMemory.Models;
using Xamarin.Forms;

namespace ExtendedMemory.Views
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();

            //load all the dopdowns - somethin like:
            //ddSearchByPeople.Items = DataAccess.MemoryDatabase.Get(SearchType.People);
            //ddSearchByTag.Items = DataAccess.MemoryDatabase.Get(SearchType.Tag);

            //async possible when takin from the db?

            ddSearchByPeople.Items.Add("Niki");
            ddSearchByPeople.Items.Add("Sumit");

            ddSearchByTag.Items.Add("Swim");
            ddSearchByTag.Items.Add("PS4");

            var dds = new Picker[] { ddSearchByPeople, ddSearchByTag, ddSearchByCity, ddSearchByState, ddSearchByCountry };
            foreach (var dd in dds)
            {
                dd.Items.Add("");
                dd.SelectedIndexChanged += (sender, e) => AppendToTextField(txtSearchByTag, dd.SelectedItem.ToString());
            }
        }

        private void AppendToTextField(Entry entry, string text)
        {
            entry.Text += text + ", ";
        }

        async void SearchMemory(object sender, EventArgs args)
        {
            try
            {
                Button button = (Button)sender;

                var a = ddSearchByPeople.SelectedItem?.ToString();

                //var b = 

                //if nothin to search
                //if (String.IsNullOrWhiteSpace(txtEntry.Text))
                //{
                //    await DisplayAlert("Enter Text", "Please enter some text", "OK");
                //    return;
                //}

                
                //if momory(s) found, different screen or current last row?
                await DisplayAlert("Success", "Memory search complete.", "OK");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}