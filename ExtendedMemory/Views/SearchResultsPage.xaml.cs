using System;
using System.Collections.Generic;
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
            var searchResult = DependencyService.Get<IMemoryDatabase>().Get();

            //Console.Write("here is the record"+searchResult.Item[0].Location);
            InitializeComponent();
        }
    }
}
