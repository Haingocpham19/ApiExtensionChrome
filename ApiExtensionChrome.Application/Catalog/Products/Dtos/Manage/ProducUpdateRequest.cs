using System;
using System.Collections.Generic;
using System.Text;

namespace ApiExtensionChrome.Application.Catalog.Products.Dtos.Manage
{
    public class ProducUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
