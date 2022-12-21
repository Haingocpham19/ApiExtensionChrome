using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiExtensionChrome.DataDemo.ModelsDemo
{
    public partial class OrderDetail
    {
        public long ProductId { get; set; }
        public long OrderId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
    }
}
