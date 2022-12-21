﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiExtensionChrome.DataDemo.ModelsDemo
{
    public partial class TrackingDetails
    {
        public long Id { get; set; }
        public long? OrderId { get; set; }
        public long? TrackingNo { get; set; }
        public string Retailer { get; set; }
        public int? Weight { get; set; }
        public string Status { get; set; }
    }
}
