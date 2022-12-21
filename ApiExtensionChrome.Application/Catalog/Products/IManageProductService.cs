using ApiExtensionChrome.Application.Catalog.Products.Dtos;
using ApiExtensionChrome.Application.Catalog.Products.Dtos.Manage;
using ApiExtensionChrome.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiExtensionChrome.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProducUpdateRequest request);
        Task<int> Delete(int productID);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdatePromotion(int productId, int addedQuantity);
        Task AddViewcount(int productId);
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);

    }
}
