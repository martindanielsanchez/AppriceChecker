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
    public partial class ProductViewPage : ContentPage
    {
        RestService _restService;
        String barcode;
        public ProductViewPage(ItemData item)
        {
            InitializeComponent();
            barcode = item.ProductId.ToString();
            itemBarcode.Text = "Barcode: " + item.ProductId.ToString();
            itemName.Text = "Name: " + item.Name;
            itemPrice.Text = "Unit Price: $" + item.UnitPrice;
            itemLocation.Text = "Location: " + item.Location;
        }

        void DeleteClicked(object sender, System.EventArgs e)
        {
            _restService = new RestService();

            //API call
            Device.BeginInvokeOnMainThread(async () =>
            {
                String message = await _restService.GetItemAdditionAsync(GenerateRequestUri(App.Global._APIendpoint));
            });

            var page = new RetailPortal();
            Navigation.PushAsync(page);
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"/DeleteProduct?barcode={barcode}";
            return requestUri;
        }
    }
}