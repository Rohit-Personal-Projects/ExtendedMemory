using System;
using ExtendedMemory.DataAccess;
using ExtendedMemory.Models;
using Xamarin.Forms;

namespace ExtendedMemory.Views
{
    public partial class SearchResultsPage : ContentPage
    {
        public SearchResultsPage()
        {
            InitializeComponent();
        }

        public SearchResultsPage(SearchParams searchParams)
        {
            InitializeComponent();

            var searchResult = new MemoryDatabase().Get(searchParams);
            Device.BeginInvokeOnMainThread(() =>
            {
                if (searchResult.IsSuccess)
                {
                    DisplayAlert("Success", searchResult.Item.Count + " results found", "OK");
                }
                else
                {
                    DisplayAlert("Failure", "Something went wrong", "OK");
                }
            });
        }

        void BackToSearch(object sender, EventArgs args)
        {
            Application.Current.MainPage = new HomePage()
            {
                CurrentPage = new SearchPage()
            };
        }
    }
}
