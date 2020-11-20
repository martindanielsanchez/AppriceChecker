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
    public partial class Registration : ContentPage
    {
        UserData user;
        RestService _restService;
        public Registration()
        {
            InitializeComponent();
           // resultScan.Text = result;
        }
        void RegisterClicked(object sender, System.EventArgs e)
        {
            user = new UserData();
            _restService = new RestService();
            if (passEntry.Text.Equals(confirmEntry.Text) && firstEntry.Text!=null && lastEntry.Text != null && emailEntry.Text != null) {
                user.Email = emailEntry.Text;
                user.First = firstEntry.Text;
                user.Last = lastEntry.Text;
                user.Password = passEntry.Text;

                //API call
                Device.BeginInvokeOnMainThread(async () =>
                {
                    String message = await _restService.GetItemAdditionAsync(GenerateRequestUri(App.Global._APIendpoint));
                });
                //Navigate to Admin Portal
                var page = new AdminPortal();
                Navigation.PushAsync(page);
            }
            else {
                messageLabel.Text = "Please check all fields are complete and passwords match";
            }
            //add code to call Scan page
            //var page = new ScanProduct();
            //Navigation.PushAsync(page);
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"/AddUser?email={user.Email}&first={user.First}&last={user.Last}&password={user.Password}&isAdmin=0";
            return requestUri;
        }

    }
}