using System;
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
    public partial class AdminPortal : ContentPage
    {
        public AdminPortal()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var menu = new List<xmenu>();

            menu.Add(new xmenu
            {
                Text = "Add Admin",
                Id = 1,
                Image = "Search"
            });
            menu.Add(new xmenu
            {
                Text = "Users List",
                Id = 2,
                Image = "box"
            });
            menu.Add(new xmenu
            {
                Text = "Retail Portal",
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
                    case "Add Admin":
                        await Navigation.PushAsync(new AddAdminPage { });
                        break;
                    case "Users List":
                        await Navigation.PushAsync(new UserListPage { });
                        break;
                    case "Retail Portal":
                        await Navigation.PushAsync(new RetailPortal { });
                        break;
                }
            }
        }
    }
}