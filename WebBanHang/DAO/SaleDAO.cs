using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHang.Models.EF;

namespace WebBanHang.DAO
{
    public class SaleDAO
    {
        private ShopMVC5DbContext db = new ShopMVC5DbContext();
        public bool Create(Product product, int discount, DateTime? beginDate, DateTime? endDate)
        {
            beginDate= beginDate??DateTime.Now;
            endDate=endDate?? DateTime.Now.AddDays(20);
            try
            {
                var sale = new Sale { ProductID = product.ID, Discount = discount, BeginDate = (DateTime)beginDate, EndDate = (DateTime)endDate };
                db.Sales.Add(sale);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
             
        }

    }
}