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
    public partial class ProductResult : ContentPage
    {
        public ProductResult(String search, Boolean byDescription)
        {
            InitializeComponent();
            productDescription.Text = search; // use the result to look up product in db
        }
        void Handle_Clicked_Search_Again(object sender, System.EventArgs e)
        {
            var page = new MainPage();
            Navigation.PushAsync(page);
        }
    }
}