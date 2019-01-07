using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHang.Models.EF;
namespace WebBanHang.DAO
{
    public class OrderDAO
    {
        private ShopMVC5DbContext db = new ShopMVC5DbContext();

        public IQueryable<Order> GetAllOrder( string search)
        {
            IQueryable<Order> orders = db.Orders.OrderByDescending(o=>o.ShipCreateDate);
            return orders;
        }
        public IQueryable<OrderDetail> GetDetails(Order order)
        {
            IQueryable<OrderDetail> details = db.OrderDetails.Where(od=>od.OrderID==order.ID);
            return details;
        }
    }
}