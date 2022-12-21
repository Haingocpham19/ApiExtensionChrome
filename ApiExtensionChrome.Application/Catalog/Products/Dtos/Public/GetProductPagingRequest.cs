using ApiExtensionChrome.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiExtensionChrome.Application.Catalog.Products.Dtos.Public
{
    public class GetProductPagingRequest:PagingRequestBase
    {
        public int? CategoryID { set; get; }
    }
}
