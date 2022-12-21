using System;
using System.Collections.Generic;
using System.Text;

namespace ApiExtensionChrome.Application.Catalog.Products.Dtos
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string MetaTitle { get; set; }
        public string Descriptions { get; set; }
        public string Image { get; set; }
        public string MoreImages { get; set; }
        public decimal? Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public bool? IncludedVat { get; set; }
        public int? Quantity { get; set; }
        public long? CategoryId { get; set; }
        public string Detail { get; set; }
        public int? Warranty { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }
        public bool? Status { get; set; }
        public DateTime? TopHot { get; set; }
        public string ViewCount { get; set; }

    }
}
