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
        String name;
        String price;
        String location;
        public ProductViewPage(ItemData item)
        {
            InitializeComponent();
            barcode = item.ProductId.ToString();
            
            itemBarcode.Text = item.ProductId.ToString();
            itemName.Text = item.Name;
            itemPrice.Text = item.UnitPrice.ToString();
            itemLocation.Text = item.Location;
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

        void UpdateClicked(object sender, System.EventArgs e)
        {

            name = itemName.Text;
            price = itemPrice.Text;
            location = itemLocation.Text;

            _restService = new RestService();

            //API call
            Device.BeginInvokeOnMainThread(async () =>
            {
                String message = await _restService.GetItemAdditionAsync(GenerateUpdateRequestUri(App.Global._APIendpoint));
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

        string GenerateUpdateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"/UpdateProduct?barcode={barcode}&name={name}&location={location}&price={price}";
            return requestUri;
        }
    }
}