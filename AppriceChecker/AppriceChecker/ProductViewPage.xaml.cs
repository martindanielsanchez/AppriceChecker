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
        public ProductViewPage(ItemData item)
        {
            InitializeComponent();
            itemBarcode.Text = "Barcode: " + item.ProductId.ToString();
            itemName.Text = "Name: " + item.Name;
            itemPrice.Text = "Unit Price: $" + item.UnitPrice;
            itemLocation.Text = "Location: " + item.Location;
        }
    }
}