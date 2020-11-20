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
    public partial class UserViewPage : ContentPage
    {
        RestService _restService;
        String email;
        String first;
        String last;
        String password;
        public UserViewPage(UserData userData)
        {
            InitializeComponent();

            email = userData.Email;
            userEmail.Text = email;
            userFirst.Text = userData.First;
            userLast.Text = userData.Last;
        }
        void DeleteClicked(object sender, System.EventArgs e)
        {
            _restService = new RestService();

            //API call
            Device.BeginInvokeOnMainThread(async () =>
            {
                String message = await _restService.GetItemAdditionAsync(GenerateRequestUri(App.Global._APIendpoint));
            });

            var page = new AdminPortal();
            Navigation.PushAsync(page);
        }

        void UpdateClicked(object sender, System.EventArgs e)
        {

            first = userFirst.Text;
            last = userLast.Text;
            password = userPassword.Text;

            _restService = new RestService();

            //API call
            Device.BeginInvokeOnMainThread(async () =>
            {
                String message = await _restService.GetItemAdditionAsync(GenerateUpdateRequestUri(App.Global._APIendpoint));
            });

            var page = new AdminPortal();
            Navigation.PushAsync(page);
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"/DeleteUser?email={email}";
            return requestUri;
        }

        string GenerateUpdateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"/UpdateUser?email={email}&first={first}&last={last}&password={password}";
            return requestUri;
        }
    }
}