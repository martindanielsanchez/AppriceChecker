using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppriceChecker
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        void Handle_Clicked_Scan(object sender, System.EventArgs e)
        {
           var page = new ScanProduct();
           Navigation.PushAsync(page);
        }
        void Handle_Clicked_Search(object sender, System.EventArgs e)
        {
            String s = productDescription.Text;
            var page = new ProductResult(s);
            Navigation.PushAsync(page);
        }
        void Handle_Clicked_Log_In(object sender, System.EventArgs e)

        {
            //String s = productDescription.Text;
            var page = new LogIn();
            Navigation.PushAsync(page);
        }
    }
}
