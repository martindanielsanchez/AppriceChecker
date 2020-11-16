using System;
using System.Collections.Generic;
using System.Text;

namespace AppriceChecker.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
