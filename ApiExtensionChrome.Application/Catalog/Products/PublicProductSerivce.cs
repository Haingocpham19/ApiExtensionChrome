using ApiExtensionChrome.Application.Catalog.Products.Dtos;
using ApiExtensionChrome.Application.Catalog.Products.Dtos.Manage;
using ApiExtensionChrome.Application.Dtos;
using ApiExtensionChrome.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ApiExtensionChrome.Application.Catalog.Products
{
    public class PublicProductSerivce : IPublicProductService
    {
        private readonly OnlineShopContext _onlineShopDbContext;
        public PublicProductSerivce(OnlineShopContext onlineShopContext)
        {
            _onlineShopDbContext = onlineShopContext;
        }

        public async Task<PagedResult<ProductViewModel>> GetAllCategoryById(Dtos.Public.GetProductPagingRequest request)
        {
            //1.select join
            var query = from x in _onlineShopDbContext.Product
                        join c in _onlineShopDbContext.ProductCategory on x.CategoryId equals c.Id
                        select new { x,c};

            //2.filter
            if (request.CategoryID.HasValue && request.CategoryID.Value > 0)
            {
                query = query.Where(c => c.x.CategoryId == request.CategoryID);
            }
            int totalRow = await query.CountAsync();

            var data = query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(p => new ProductViewModel()
            {
                CategoryId = request.CategoryID
            }).ToListAsync();
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }
    }
}
