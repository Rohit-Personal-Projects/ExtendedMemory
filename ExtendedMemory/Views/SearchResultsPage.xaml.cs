using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            var searchResult = DependencyService.Get<IMemoryDatabase>().Get();

            //Console.Write("here is the record"+searchResult.Item[0].Location);
            //var listView = new ListView();
            var listView = new ListView();
            ObservableCollection<Memory> mems = new ObservableCollection<Memory>();
            //foreach(var x in searchResult.Result.Item){
            //    mems.Add(x);
            //}
            mems.Add(new Memory{Text = "Nikitha"});
            Memory.ItemsSource = searchResult.Item;

        }
    }
}
