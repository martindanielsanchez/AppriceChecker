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
    public partial class UserListPage : ContentPage
    {
        RestService _restService;
        String email;
        public UserListPage()
        {
            InitializeComponent();
            _restService = new RestService();
            email = "0";
            int count = 0;
            Device.BeginInvokeOnMainThread(async () =>
            {
                //productDescription.Text = "1";
                IEnumerable<Models.UserData> userDatas = await _restService.GetUserListAsync(GenerateRequestUri(App.Global._APIendpoint));
                //productDescription.Text = "3";
                if (userDatas != null)
                {
                    productDescription.Text = "";
                    var menu = new List<umenu>();
                    foreach (Models.UserData userData in userDatas)
                    {
                        //productDescription.Text += itemData.Name + "\r\n";
                        menu.Add(new umenu
                        {
                            Text = userData.Email + "\r\n" + userData.First + " " + userData.Last,
                            Id = count,
                            Image = "Search",
                            user = userData
                        });
                        count++;
                    }
                    xlistView.ItemsSource = menu.ToList();
                    //productDescription.Text = "Barcode: " + itemData.ProductId + " Name: " + itemData.Name + " Location: " + itemData.Location + " Unit Price: $" + itemData.UnitPrice;
                    //productDescription.Text = itemData.ToString();
                }
                else
                {
                    productDescription.Text = "User not found";
                }
                //productDescription.Text = "4";
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                umenu user = (umenu)xlistView.SelectedItem;
                //call product view page

                await Navigation.PushAsync(new UserViewPage(user.user) { });

            }
        }
        string GenerateRequestUri(string endpoint)
        {
            //productDescription.Text = "2";
            string requestUri = endpoint;
            requestUri += $"/GetUser?email={email}";
            return requestUri;
        }
    }
}