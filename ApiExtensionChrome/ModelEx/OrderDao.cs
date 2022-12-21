using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiExtensionChrome.Data.Models;
using ApiExtensionChrome.Model;

namespace ApiExtensionChrome.ModelEx
{
    public class OrderDao
    {
        OnlineShopContext db = null;
        public OrderDao()
        {
            db = new OnlineShopContext();
        }
        //public IEnumerable<TrackingExtra> ViewOrderDetail(long? id)
        //{
        //    var dao = new Product();
        //    var result = from a in db.Order
        //                 join b in db.OrderDetail on a.Id equals b.OrderId
        //                 join c in db.Product on b.ProductId equals c.Id
        //                 join d in db.TrackingDetails on a.Id equals d.OrderId
        //                 where d.TrackingNo == id
        //                 select new TrackingExtra()
        //                 {
        //                     TotalPrice = a.TotalPrice,
        //                     ProductName = c.Name,
        //                     OrderID = a.Id,
        //                     ProductID = b.ProductId,
        //                     Quantity = b.Quantity,
        //                     Price = b.Price,
        //                     QuantityinStock = c.Quantity,
        //                     TrackingNo = d.TrackingNo,
        //                     Retailer = d.Retailer,
        //                     Weight = d.Weight,
        //                     Status = d.Status
        //                 };
        //    return result.OrderBy(x => x.ProductID);
        //}
    }
}
