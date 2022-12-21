using ApiExtensionChrome.Application.Catalog.Products.Dtos;
using ApiExtensionChrome.Application.Catalog.Products.Dtos.Manage;
using ApiExtensionChrome.Application.Dtos;
using ApiExtensionChrome.Data.Models;
using ApiExtensionChrome.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiExtensionChrome.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly OnlineShopContext _onlineShopDbContext;
        public ManageProductService(OnlineShopContext onlineShopContext)
        {
            _onlineShopDbContext = onlineShopContext;
        }
        public async Task AddViewcount(int productId)
        {
            var product = await _onlineShopDbContext.Product.FindAsync(productId);
            product.ViewCount += 1;
            await _onlineShopDbContext.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                PromotionPrice = request.PromotionPrice,
                Image = request.Image,
                ViewCount = "0",
                CreateDate = (DateTime.Now)
            };
            _onlineShopDbContext.Product.Add(product);
            return await _onlineShopDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int productID)
        {
            var product = await _onlineShopDbContext.Product.FindAsync(productID);
            if (product == null) throw new ApiChromeExtensionException($"Cannot find a product: {productID}");
            _onlineShopDbContext.Product.Remove(product);
            return await _onlineShopDbContext.SaveChangesAsync();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            var query = from x in _onlineShopDbContext.Product
                        join c in _onlineShopDbContext.ProductCategory on x.CategoryId equals c.Id
                        select x;
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.Name.Contains(request.Keyword));
            int totalRow = await query.CountAsync();
            var data = query.Skip((request.PageIndex - 1)*request.PageSize).Take(request.PageSize).Select(p=>new ProductViewModel() {
                Id=p.Id,
                Name=p.Name,
                CreateDate=p.CreateDate,
                Descriptions=p.Descriptions,
                Detail=p.Detail,
                Warranty=p.Warranty,
                Price=p.Price,
                Code=p.Code,
                Image=p.Image,
                PromotionPrice=p.PromotionPrice,
                CreateBy=p.CreateBy,
                ViewCount=p.ViewCount
            }).ToListAsync();
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<int> Update(ProducUpdateRequest request)
        {
            var product = _onlineShopDbContext.Product.Find(request.Id);
            if (product == null) throw new ApiChromeExtensionException($"Cannot find product ID:{request.Id}");
            product.Name = request.Name;
            product.Quantity = request.Quantity;

            return await _onlineShopDbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = _onlineShopDbContext.Product.Find(productId);
            if (product == null) throw new ApiChromeExtensionException($"Cannot find product ID:{productId}");
            product.Price = newPrice;
            return await _onlineShopDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePromotion(int productId, int addedQuantity)
        {
            var product = _onlineShopDbContext.Product.Find(productId);
            if (product == null) throw new ApiChromeExtensionException($"Cannot find product ID:{productId}");
            product.Quantity = addedQuantity;
            return await _onlineShopDbContext.SaveChangesAsync() > 0;
        }
    }
}
