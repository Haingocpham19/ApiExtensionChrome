using ApiExtensionChrome.Model;
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
    public class TrackingController : ControllerBase
    {
        //[HttpGet("{id}")]
        //public IEnumerable<TrackingExtra> Get(long id)
        //{
        //    return new OrderDao().ViewOrderDetail(id);
        //}

        //[HttpPost]
        //public IEnumerable<TrackingExtra> Post(TrackingExtra trackingEx)
        //{
        //    return new OrderDao().ViewOrderDetail(trackingEx.TrackingNo);
        //}
        // PUT api/<TrackingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TrackingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
