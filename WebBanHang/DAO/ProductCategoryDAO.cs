using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebBanHang.Models.EF;

namespace WebBanHang.DAO
{
    public class ProductCategoryDAO
    {
        private ShopMVC5DbContext db = new ShopMVC5DbContext();
        public IQueryable<ProductCategory> GetAllProCategory()
        {
            IQueryable<ProductCategory> proCategories = db.ProductCategories.OrderBy(p=>p.Name);
            return proCategories;
        }
        public long Create(string name, string metatitle)
        {
            var check = db.ProductCategories.SingleOrDefault(p => p.Name == name);
            if(check==null)
            {
                var proCategory = new ProductCategory { Name = name, MetaTitle = metatitle };
                db.ProductCategories.Add(proCategory);
                db.SaveChanges();
                return proCategory.ID;
            }
            return -1;
        }

        public long Edit(long id, string name,string metatitle)
        {
            var check = db.ProductCategories.SingleOrDefault(p => p.Name == name);
            if (check == null)
            {
                var proCategory = db.ProductCategories.Find(id);
                proCategory.Name = name;
                proCategory.MetaTitle = metatitle;
                db.Entry(proCategory).State = EntityState.Modified;
                db.SaveChanges();               
                return proCategory.ID;
            }
            return -1;
        }
    }
}