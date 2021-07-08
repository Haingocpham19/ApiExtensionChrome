using ApiExtensionChrome.ModelEx;
using ApiExtensionChrome.Models;
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
    public class ValuesController : ControllerBase
    {
        logindbContext context = new logindbContext();
        // GET: api/<ValuesController>
        [HttpGet]
        public List<AdminLogin> ListAll()
        {
            return new AdminLoginDao().ListUser();
        }
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public List<AdminLogin> Edit(int id)
        {
            return new AdminLoginDao().GetUserById(id);
        }
        // POST api/<ValuesController>
        [HttpPost]
        public bool Create([FromBody] AdminLogin value)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminLoginDao();
                long id = dao.Insert(value);
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
        public bool Update([FromRoute]int id,[FromBody] AdminLogin value)
        {           
            var existingUser = context.AdminLogin.FirstOrDefault(x => x.Id == id);
            if (existingUser != null)
            {
                value.UserName = value.UserName;
                value.Password = value.Password;
                context.SaveChanges();
                return true;
            }
            return false;
        }
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            AdminLoginDao dao = new AdminLoginDao();
            if (dao.Delete(id)) {
                return true;
            };
            return false;
        }
    }
}
