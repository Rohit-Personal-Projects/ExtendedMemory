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
            if (searchResult.IsSuccess)
            {
                Memory.ItemsSource = searchResult.Item;
                Device.BeginInvokeOnMainThread(() => DisplayAlert("Success", searchResult.Item.Count + " results found", "OK"));
            }
            else
            {
                Device.BeginInvokeOnMainThread(() => DisplayAlert("Failure", "Something went wrong", "OK"));
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
