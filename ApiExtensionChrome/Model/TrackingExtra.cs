using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExtensionChrome.Model
{
    public class TrackingExtra
    {
        public string ProductName { set; get; }
        public long ID { set; get; }
        public long ProductID { set; get; }
        public long OrderID { set; get; }
        public int? Quantity { set; get; }
        public decimal? Price { set; get; }
        public int? QuantityinStock { set; get; }
        public long? TrackingNo { set; get; }
        public string Retailer { set; get; }
        public int? Weight { set; get; }
        public string Status { set; get; }
        public long? TotalPrice { set; get; }
    }
}
