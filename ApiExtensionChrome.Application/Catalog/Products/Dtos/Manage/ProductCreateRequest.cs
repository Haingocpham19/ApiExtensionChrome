using System;
using System.Collections.Generic;
using System.Text;

namespace ApiExtensionChrome.Application.Catalog.Products.Dtos.Manage
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }
        public decimal PromotionPrice { get; set; }
        public decimal Price { get; set; }
        public string Code { get; set; }
        public string MetaTitle { get; set; }
        public string Descriptions { get; set; }
        public string Image { get; set; }
        public string MoreImages { get; set; }
    }
}
