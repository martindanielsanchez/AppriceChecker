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
    public partial class ProductListPage : ContentPage
    {
        String bar;
        RestService _restService;
        
        public ProductListPage()
        {
            InitializeComponent();
            _restService = new RestService();
            bar = "0";
            int count = 0;
            Device.BeginInvokeOnMainThread(async () =>
            {
                //productDescription.Text = "1";
                IEnumerable<Models.ItemData> itemDatas = await _restService.GetItemListAsync(GenerateRequestUri(App.Global._APIendpoint));
                //productDescription.Text = "3";
                if (itemDatas != null)
                {
                    productDescription.Text = "";
                    var menu = new List<pmenu>();
                    foreach (Models.ItemData itemData in itemDatas)
                    {
                        //productDescription.Text += itemData.Name + "\r\n";
                        menu.Add(new pmenu
                        {
                            Text = itemData.Name,
                            Id = count,
                            Image = "Search",
                            item = itemData
                        });
                        count++;
                    }
                    xlistView.ItemsSource = menu.ToList();
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
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    var menu = new List<pmenu>();

        //    menu.Add(new pmenu
        //    {
        //        Text = "Add Products",
        //        Id = 1,
        //        Image = "Search"
        //    });
        //    menu.Add(new pmenu
        //    {
        //        Text = "Products List",
        //        Id = 2,
        //        Image = "box"
        //    });
        //    menu.Add(new pmenu
        //    {
        //        Text = "Most Searched Report",
        //        Id = 3,
        //        Image = "Invoice"
        //    });

        //    //ListView.ItemsSource = menu.ToList();
        //    xlistView.ItemsSource = menu.ToList();

        //}
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                pmenu item = (pmenu)xlistView.SelectedItem;
                //call product view page
                await Navigation.PushAsync(new ProductViewPage(item.item) { });

            }
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