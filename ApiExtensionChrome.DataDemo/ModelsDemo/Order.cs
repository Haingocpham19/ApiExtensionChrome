using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiExtensionChrome.DataDemo.ModelsDemo
{
    public partial class Order
    {
        public long Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public long? CustomerId { get; set; }
        public string ShipName { get; set; }
        public string ShipMobile { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
        public long? TotalPrice { get; set; }
        public int? Status { get; set; }
    }
}
