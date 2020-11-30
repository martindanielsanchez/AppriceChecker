using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AppriceChecker.Models
{
    public class ItemData
    {
        [JsonProperty("ProductId")]
        public string ProductId { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Location")]
        public string Location { get; set; }
        [JsonProperty("UnitPrice")]
        public decimal UnitPrice { get; set; }

    }
}
