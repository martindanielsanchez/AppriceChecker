﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppriceChecker.Models;

namespace AppriceChecker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RetailPortal : ContentPage
    {
        public RetailPortal()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var menu = new List<xmenu>();

            menu.Add(new xmenu
            {
                Text = "Add Products",
                Id = 1,
                Image = "Search"
            });
            menu.Add(new xmenu
            {
                Text = "Products List",
                Id = 2,
                Image = "box"
            });
            menu.Add(new xmenu
            {
                Text = "Most Searched Report",
                Id = 3,
                Image = "Invoice"
            });

            //ListView.ItemsSource = menu.ToList();
            xlistView.ItemsSource = menu.ToList();

        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                xmenu item = (xmenu)xlistView.SelectedItem;
                //await DisplayAlert("Alert", "Item selected " + item.Text, "OK");
                switch (item.Text)
                {
                    case "Add Products":
                        await Navigation.PushAsync(new AddProductPage { });
                        break;
                    case "Products List":
                        await Navigation.PushAsync(new ProductListPage { });
                        break;
                    case "Most Searched Report":
                        await Navigation.PushAsync(new ReportPage { });
                        break;
                }
            }
        }
    }
}