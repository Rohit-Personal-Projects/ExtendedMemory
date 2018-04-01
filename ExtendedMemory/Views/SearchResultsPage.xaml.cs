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

            //Console.Write("here is the record"+searchResult.Item[0].Location);

            DisplayAlert(searchResult.IsSuccess ? "Success" : "Failure", searchResult.Item.ToString(), "OK");
            //DisplayAlert("Success", "Memory search complete.", "OK");

            Application.Current.MainPage = new SearchPage();
        }
    }
}
