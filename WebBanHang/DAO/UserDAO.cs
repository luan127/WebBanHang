using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebBanHang.Models.EF;
using WebBanHang.Areas.Admin.Models;
namespace WebBanHang.DAO
{
    public class UserDAO
    {
        private ShopMVC5DbContext db = new ShopMVC5DbContext();
        public IQueryable<User> GetAllUser(string searchStr)
        {
            IQueryable<User> users = db.Users.OrderBy(u=>u.Username);
            if (!String.IsNullOrEmpty(searchStr)) users = users.Where(u => u.Username.Contains(searchStr));
            return users;
        }
        public User getUserByUserName(string userName)
        {
            var user = db.Users.SingleOrDefault(u => u.Username == userName);
            return user;
        }
        public int UserLogin(LoginModel login)
        {
            var check = db.Users.SingleOrDefault(u => u.Username == login.Username);
            if(check!=null)
            {
                if (check.Password == login.Password)
                {
                    if (check.Block == true) return 2;//bi block
                    else
                    {
                        if (check.Permission == 1) return 1;//admin
                        if (check.Permission == 0) return 0;//user
                    }

                }
                else return 3;//sai mat khau
            }
            return -1;//tai khoan khong ton tai
        }
        public long Create(User user)
        {
            var check = db.Users.SingleOrDefault(u => u.Username == user.Username);
            if (check == null)
            {
                user.CreateDate = DateTime.Now;
                user.Active = true;
                user.Block = false; 
                db.Users.Add(user);
                db.SaveChanges();
                return user.ID;
            }
            else return -1;                     
        }
        public bool Delete(long id)
        {
            try
            {
                var user = db.Users.Find(id);
                if (user.Permission == 1) return false;
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(User user)
        {
            try
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public int ChangeBlock(long id)
        {
            try
            {
                var user = db.Users.Find(id);
                user.Block = !user.Block;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                if (user.Block == true) return 1;
                else return 0;
            }
            catch
            {
                return -1;
            }            
        }
        public bool ChangePass(long id, string oldPass, string newPass)
        {
            var user = db.Users.Find(id);
            if(user!=null)
            {
                if (user.Password == oldPass)
                {
                    user.Password = newPass;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else return false;
            }
            return false;
        }
    }
}