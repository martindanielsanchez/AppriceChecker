using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppriceChecker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {
        public LogIn()
        {
            InitializeComponent();
        }
        void LogInClicked(object sender, System.EventArgs e)
        {
            var page = new AdminPortal(); //Check if user is Admin, if so go to Admin Portal, if not to Retail Portal
            Navigation.PushAsync(page);
        }
        void GoBackClicked(object sender, System.EventArgs e)
        {
            var page = new MainPage();
            Navigation.PushAsync(page);
        }
    }
}