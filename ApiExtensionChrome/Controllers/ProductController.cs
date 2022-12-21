using ApiExtensionChrome.Data.Models;
using ApiExtensionChrome.ModelEx;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiExtensionChrome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        OnlineShopContext context = new OnlineShopContext();
        // GET: api/<ValuesController>
        [HttpGet]
        public List<Product> Get()
        {
            var listFeatureProduct = new ProductDao().ListFeatureProduct(10);
            return listFeatureProduct;
        }

        [HttpGet("id")]
        public List<Product> GetProductById(long id)
        {
            var getProductById = new ProductDao().getProductById(id);
            return getProductById;
        }
        // POST api/<ValuesController>
        [HttpPost]
        public bool Create([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                long id = dao.Insert(product);
                if (id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public bool Update([FromRoute] int id, [FromBody] Product value)
        {
            var existingProduct = context.Product.FirstOrDefault(x => x.Id == id);
            if (existingProduct != null)
            {
                existingProduct.Name = value.Name;
                new ProductDao().Save();
                return true;
            }
            return false;
        }
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            ProductDao dao = new ProductDao();
            if (dao.Delete(id))
            {
                return true;
            };
            return false;
        }
    }
}
