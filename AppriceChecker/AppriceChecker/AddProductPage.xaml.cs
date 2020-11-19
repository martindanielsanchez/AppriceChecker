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
    public partial class AddProductPage : ContentPage
    {
        RestService _restService;
        ItemData itemData;

        public AddProductPage()
        {
            InitializeComponent();
        }
        void AddClicked(object sender, System.EventArgs e)
        {
            _restService = new RestService();
            itemData = new ItemData();
            int i = 0;
            int j = 0;
            string d = priceEntry.Text;
            string s = barcodeEntry.Text;
            bool result = int.TryParse(s, out i);
            bool result2 = int.TryParse(d, out j); //change to double
            if (result && nameEntry.Text !=null && result2)
            {
                itemData.ProductId = i;
                itemData.Name = nameEntry.Text;
                itemData.UnitPrice = j;
                itemData.Location = locationEntry.Text;
                //API call
                Device.BeginInvokeOnMainThread(async () =>
                {
                    String message = await _restService.GetItemAdditionAsync(GenerateRequestUri(App.Global._APIendpoint));
                });
                //Navigate to Retail Portal
                var page = new RetailPortal();
                Navigation.PushAsync(page);
            }
            else {
                messageLabel.Text = "Please enter valid values";
            }
        }
        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"/AddProduct?barcode={itemData.ProductId}&name={itemData.Name}&location={itemData.Location}&price={itemData.UnitPrice}";
            return requestUri;
        }
    }
}