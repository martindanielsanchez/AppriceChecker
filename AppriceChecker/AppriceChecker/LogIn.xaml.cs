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
    public partial class LogIn : ContentPage
    {
        UserData user;
        RestService _restService;
        String email;
        String password;
        
        public LogIn()
        {
            InitializeComponent();
        }
        void LogInClicked(object sender, System.EventArgs e)
        {
            user = new UserData();
            _restService = new RestService();
            Boolean isAdmin = false;
            Boolean isUser = false;

            email = emailEntry.Text;
            password = passEntry.Text;

            Device.BeginInvokeOnMainThread(async () =>
            {
                IEnumerable<Models.UserData> userDatas = await _restService.GetUserListAsync(GenerateRequestUri(App.Global._APIendpoint));
                //productDescription.Text = "3";
                if (!userDatas.Any())
                {
                    emailEntry.Text = "Wrong credentials!";
                }
                else //successful login
                {
                    if (userDatas.ElementAt(0).IsAdmin)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new AdminPortal());
                    }
                    else
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new RetailPortal());
                    }
                }
            });

        }
        void GoBackClicked(object sender, System.EventArgs e)
        {
            var page = new MainPage();
            Navigation.PushAsync(page);
        }

        string GenerateRequestUri(string endpoint)
        {
            //productDescription.Text = "2";
            string requestUri = endpoint;
            requestUri += $"/LogInUser?email={email}&password={password}";
            return requestUri;
        }
    }
}