using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiExtensionChrome.Data.Models
{
    public partial class ProductCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MetaTilte { get; set; }
        public long? ParentId { get; set; }
        public int? DisplayOrder { get; set; }
        public string SeoTilte { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }
        public bool? Status { get; set; }
        public bool? ShowOnHome { get; set; }
    }
}
