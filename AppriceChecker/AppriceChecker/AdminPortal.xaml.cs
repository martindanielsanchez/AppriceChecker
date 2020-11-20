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
                Image = "worker"
            });
            menu.Add(new xmenu
            {
                Text = "Add User",
                Id = 2,
                Image = "businessman"
            });
            menu.Add(new xmenu
            {
                Text = "Users List",
                Id = 3,
                Image = "teamwork"
            });
            menu.Add(new xmenu
            {
                Text = "Retail Portal",
                Id = 4,
                Image = "cashier"
            });
            menu.Add(new xmenu
            {
                Text = "Consumer Portal",
                Id = 5,
                Image = "searchitem"
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
                    case "Add User":
                        await Navigation.PushAsync(new Registration { });
                        break;
                    case "Users List":
                        await Navigation.PushAsync(new UserListPage { });
                        break;
                    case "Retail Portal":
                        await Navigation.PushAsync(new RetailPortal { });
                        break;
                    case "Consumer Portal":
                        await Navigation.PopToRootAsync(); //essentially logs off so consumers can't access Admin portal by going back on previous pages
                        break;
                }
            }
        }
    }
}