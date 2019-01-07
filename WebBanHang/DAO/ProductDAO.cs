using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebBanHang.Models.EF;

namespace WebBanHang.DAO
{
    public class ProductDAO
    {
        private ShopMVC5DbContext db = new ShopMVC5DbContext();
        public IQueryable<Product> GetAllProduct(string searchStr, string searchProducer)
        {

           // IQueryable<Product> product = db.Products;
            IQueryable<Product> products = db.Products.Where(p=>p.Status==true);
            if (!String.IsNullOrEmpty(searchStr))
            {
                products = products.Where(p => p.Name.Contains(searchStr));
            }
            if (!String.IsNullOrEmpty(searchProducer))
            {
                products = products.Where(p => p.Producer.Name.Contains(searchProducer));
            }
            return products.OrderByDescending(p=>p.CreateDate);
        }

        /////ADMIN////////
        public long Create(Product product)
        {
            var check = db.Products.SingleOrDefault(p => p.Name == product.Name);
            if (check == null)
            {
                product.CreateDate = DateTime.Now;
                product.IsHot = false;
                product.Status = true;
                db.Products.Add(product);
                db.SaveChanges();
                return product.ID;
            }
            else return -1;
        }
        /// <summary>
        /// Sửa sản phẩm
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool Update(Product product)
        {
           try
            {
                var pro = db.Products.Find(product.ID);
                pro.Description = product.Description;
                pro.Detail = product.Detail;
                pro.Name = product.Name;
                pro.Price = product.Price;
                pro.ProductCategoryID = product.ProductCategoryID;
                pro.ProducerID = product.ProducerID;
                pro.Quantity = product.Quantity;
                pro.Code = product.Code;
                pro.MetaTitle = product.MetaTitle;

                db.Entry(pro).State =EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch(Exception )
           {
               return false;
           }
        }

        /// <summary>
        /// Sản phẩm đã disable
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
       
        public IQueryable<Product> GetDisableProduct(string searchStr)
        {
            
            IQueryable<Product> products = db.Products.Where(p => p.Status == false);
            if (!String.IsNullOrEmpty(searchStr))
            {
                products = products.Where(p => p.Name.Contains(searchStr));
            }
            return products.OrderByDescending(p => p.CreateDate);
        }
        public int DeleteProduct(long id)
        {
            var product = db.Products.Find(id);
            if (product == null) return -1;
            else
            {
                try
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                    return 1;
                }
                catch(Exception)
                {
                    return -1;
                }
               
            }
        }

        
    }
}