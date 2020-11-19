using System;
using System.Collections.Generic;
using System.Text;

namespace AppriceChecker.Models
{
    class UserData
    {
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("First")]
        public string First { get; set; }
        [JsonProperty("Last")]
        public string Last { get; set; }
        [JsonProperty("IsAdmin")]
        public  Boolean IsAdmin { get; set; }
    }
}
