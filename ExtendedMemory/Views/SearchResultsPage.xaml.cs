using System;
using System.Collections.Generic;
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
                for (var i = 0; i < ListViewItems.Count; i++)
                {
                    var item = ListViewItems.ElementAt(i);
                    if (item.CustomEquals((Memory)e.Item))
                    {
                        var itemClone = item;
                        ListViewItems.Remove(item);
                        itemClone.ShowHideDetails();
                        ListViewItems.Insert(i, itemClone);
                        break;
                    }
                }

                BindingContext = this;
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
            Application.Current.MainPage = new HomePage()
            {
                CurrentPage = new SearchPage()
            };
        }
    }
}
