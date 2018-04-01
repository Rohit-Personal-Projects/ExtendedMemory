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
            var searchResult = DependencyService.Get<IMemoryDatabase>().Get(searchParams);
            if (searchResult.IsSuccess)
            {
                DisplayAlert("Success", searchResult.Item.Count + " results found", "OK");
            }
            else {
                DisplayAlert("Failure", "Something went wrong", "OK");
            }

            Application.Current.MainPage = new HomePage() {CurrentPage = new SearchPage()};
        }
    }
}
