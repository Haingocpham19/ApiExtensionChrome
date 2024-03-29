﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiExtensionChrome.Data.Models
{
    public partial class Slide
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int? DisplayOrder { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Status { get; set; }
        public string CreateBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
