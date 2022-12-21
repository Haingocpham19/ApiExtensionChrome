using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiExtensionChrome.Common;
using ApiExtensionChrome.Data.Models;

namespace Model.Dao
{
    public class UserDao
    {
        OnlineShopContext db = null;
        public UserDao()
        {
            db = new OnlineShopContext();
        }
        public List<User> ListAllUser()
        {
            return db.User.OrderBy(x => x.CreateDate).ToList();
        }
        public IEnumerable<User> ListAllPaging(string searchString)
        {
            IQueryable<User> model = db.User;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate);
        }
        public long Insert(User entity)
        {
            db.User.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.User.Find(entity.Id);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = entity.ModifiedDate;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //logging
                return false;
            }

        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.User.Find(id);
                db.User.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = db.User.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.GroupId == CommonConstants.ADMIN_GROUP || result.GroupId == CommonConstants.MOD_GROUP)
                    {
                        if (result.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.Password == passWord)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Password == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }

            }
        }
        public User ViewDetail(int id)
        {
            return db.User.Find(id);
        }
        public User GetByID(string userName)
        {
            return db.User.SingleOrDefault(x => x.UserName == userName);
        }
        public bool CheckUserName(string userName)
        {
            return db.User.Count(x => x.UserName == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.User.Count(x => x.UserName == email) > 0;
        }
        public bool? ChangeStatus(long id)
        {
            var user = db.User.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }

    }
}
