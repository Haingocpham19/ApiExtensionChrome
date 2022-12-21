using ApiExtensionChrome.Application.Catalog.Products.Dtos;
using ApiExtensionChrome.Application.Catalog.Products.Dtos.Public;
using ApiExtensionChrome.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiExtensionChrome.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllCategoryById(Dtos.Public.GetProductPagingRequest request);
    }
}
