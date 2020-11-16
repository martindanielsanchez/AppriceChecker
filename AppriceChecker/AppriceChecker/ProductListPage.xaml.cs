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
    public partial class ProductListPage : ContentPage
    {
        String bar;
        RestService _restService;
        public ProductListPage()
        {
            InitializeComponent();
            _restService = new RestService();
            bar = "0"; 
            Device.BeginInvokeOnMainThread(async () =>
            {
                //productDescription.Text = "1";
                IEnumerable<Models.ItemData> itemDatas = await _restService.GetItemListAsync(GenerateRequestUri(App.Global._APIendpoint));
                //productDescription.Text = "3";
                if (itemDatas != null)
                {
                    productDescription.Text = "";
                    foreach(Models.ItemData itemData in itemDatas)
                    {
                        productDescription.Text += itemData.Name + "\r\n";
                    }
                    //productDescription.Text = "Barcode: " + itemData.ProductId + " Name: " + itemData.Name + " Location: " + itemData.Location + " Unit Price: $" + itemData.UnitPrice;
                    //productDescription.Text = itemData.ToString();
                }
                else
                {
                    productDescription.Text = "Product not found";
                }
                //productDescription.Text = "4";
            });
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