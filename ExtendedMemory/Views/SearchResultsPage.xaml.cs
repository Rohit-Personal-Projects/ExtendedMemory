using System;
using System.Collections.ObjectModel;
using System.Linq;
using ExtendedMemory.DataAccess;
using ExtendedMemory.Models;
using Xamarin.Forms;

namespace ExtendedMemory.Views
{
    public partial class SearchResultsPage : ContentPage
    {
        public ObservableCollection<Memory> ListViewItems { get; set; } = new ObservableCollection<Memory>();

        public SearchResultsPage()
        {
            InitializeComponent();
        }

        public SearchResultsPage(SearchParams searchParams)
        {
            InitializeComponent();
            stackResult.Padding = new Thickness(20, 10);

            Memories.ItemTapped += (sender, e) =>
            {
                Device.BeginInvokeOnMainThread(() => DisplayAlert(((Memory)e.Item).Text, ((Memory)e.Item).MemoryDetails(), "OK"));
            };

            var searchResult = new MemoryDatabase().Get(searchParams);
            if (searchResult.IsSuccess && searchResult.Item != null && searchResult.Item.Any())
            {
                ListViewItems = searchResult.Item;
                BindingContext = this;
                headerSearchResults.Text = $"{searchResult.Item.Count} Memories";
            }
            else
            {
                headerSearchResults.Text = $"No Memories matching this search criterion.";
            }
        }

        void BackToSearch(object sender, EventArgs args)
        {
            Application.Current.MainPage = new HomePage();
        }
    }
}
