using ApiExtensionChrome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExtensionChrome.ModelEx
{
    public class AdminLoginDao
    {
        logindbContext context = null;
        public AdminLoginDao()
        {
            context = new logindbContext();
        }
        public AdminLogin ViewDetail(long id)
        {
            return context.AdminLogin.Find(id);
        }
        public List<AdminLogin> ListUser()
        {
            return context.AdminLogin.Take(20).ToList();
        }
        public List<AdminLogin> GetUserById(int id)
        {
            return context.AdminLogin.Where(x => x.Id == id).ToList();
        }
        public long Insert(AdminLogin adminLogin)
        {
            context.AdminLogin.Add(adminLogin);
            context.SaveChanges();
            return adminLogin.Id;
        }
        public bool Delete(int id)
        {
            try
            {
                var content = context.AdminLogin.Find(id);
                context.AdminLogin.Remove(content);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
     
    }
}
