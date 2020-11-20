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
        String bar;
        RestService _restService;
        public ProductResult(String search)
        {
            InitializeComponent();
            _restService = new RestService();
            bar = search; // use the result to look up product in db
            Device.BeginInvokeOnMainThread(async () =>
            {
                //productDescription.Text = "1";
                Models.ItemData itemData = await _restService.GetItemAsync(GenerateRequestUri(App.Global._APIendpoint));
                //productDescription.Text = "3";
                if (itemData != null)
                {
                    productDescription.Text = "Barcode: " + itemData.ProductId + "\r\n" + "Name: " + itemData.Name + "\r\n" + "Location: " + itemData.Location + "\r\n" + "Unit Price: $" + itemData.UnitPrice;
                }
                else {
                    productDescription.Text = "Product not found";
                }
                    //productDescription.Text = "4";
            });
            


        }
        void Handle_Clicked_Search_Again(object sender, System.EventArgs e)
        {
            var page = new MainPage();
            Navigation.PushAsync(page);
        }

        string GenerateRequestUri(string endpoint)
        {
            //productDescription.Text = "2";
            string requestUri = endpoint;
            requestUri += $"/GetProduct?barcode={bar}";
            return requestUri;
        }
    }
}