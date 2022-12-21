using ApiExtensionChrome.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExtensionChrome.ModelEx
{
    public class ProductDao
    {
        OnlineShopContext context = null;
        public ProductDao()
        {
            context = new OnlineShopContext();
        }
        public Product ViewDetail(long id)
        {
            return context.Product.Find(id);
        }
        public List<Product> getProductById(long id)
        {
            return context.Product.Where(x => x.Id == id).ToList();
        }
        public List<Product> ListFeatureProduct(int top)
        {
            return context.Product.Where(x => x.TopHot != null & x.PromotionPrice != null).OrderBy(x => x.CreateDate).Take(top).ToList();
        }
        public IEnumerable<Product> SearchString(Product product)
        {
            IQueryable<Product> model = context.Product;
            if (!string.IsNullOrEmpty(product.Name))
            {
                model = model.Where(x => x.Name.Contains(product.Name));
            }
            return model.OrderByDescending(x => x.CreateDate);
        }
        public List<Product> ListProduct()
        {
            return context.Product.ToList();
        }
        //public Task<List<Product>> GetProductById(int id)
        //{
        //    //return context.Product.Where(x => x.Id == id).ToList();
        //}
        public long Insert(Product product)
        {
            context.Product.Add(product);
            return product.Id;
        }
        public bool Delete(int id)
        {
            try
            {
                var content = context.Product.Find(id);
                context.Product.Remove(content);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
