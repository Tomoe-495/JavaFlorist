using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JavaFlorist.Models
{
    public class CartItems
    {

        public int CARTID { get; set; }
        public string NAME { get; set; }
        public double PRICE { get; set; }
        public string IMG { get; set; }
        public int QUANTITY { get; set; }

    }
}