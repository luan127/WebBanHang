using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHang.Models.EF;

namespace WebBanHang.Models
{
    
    public class MenuItem
    {
        public List<Producer> Producers { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
    public class MainMenuModel
    {
        private ShopMVC5DbContext db = new ShopMVC5DbContext();

        private List<Producer> GetProducerList(long id) 
        {
                List<Producer> ProducerList = (from p in db.Products where p.ID == id select p.Producer).Distinct().ToList();
                return ProducerList;
        }
        public List<MenuItem> GetMenuList()
        {
            List<MenuItem> menu = new List<MenuItem>();
            var LoaiSp = db.ProductCategories.OrderBy(p => p.ID).ToList();
            foreach(var item in LoaiSp)
            {
                MenuItem ViewItem = new MenuItem();
                ViewItem.ProductCategory = item;
                ViewItem.Producers = this.GetProducerList(item.ID);
                menu.Add(ViewItem);
            }
            return menu;
        }
    }

}