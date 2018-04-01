﻿using System;
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

            var searchResult = new MemoryDatabase().Get(searchParams);

            var listView = new ListView();
            ObservableCollection<Memory> mems = new ObservableCollection<Memory>();

            mems.Add(new Memory{Text = "Nikitha"});
            Memory.ItemsSource = searchResult.Item;
              
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
