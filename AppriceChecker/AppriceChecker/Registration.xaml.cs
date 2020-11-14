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
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
           // resultScan.Text = result;
        }
        void RegisterClicked(object sender, System.EventArgs e)
        {
            //add code to call Scan page
            //var page = new ScanProduct();
            //Navigation.PushAsync(page);
        }
    }
}