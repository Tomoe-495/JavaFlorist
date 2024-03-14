using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JavaFlorist.Models
{
    public class OrderItem
    {

        public int ORDERID { get; set; }
        public string NAME { get; set; }
        public string ADDRESS { get; set; }
        public string PHONE { get; set; }
        public System.DateTime DATE { get; set; }
        public int QUANTITY { get; set; }
        public double TOTALPRICE { get; set; }
        public string IMG { get; set; }
        public string MESSAGE { get; set; }

    }
}