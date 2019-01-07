using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebBanHang.Models.EF;
namespace WebBanHang.DAO
{
    public class ProducerDAO
    {
        private ShopMVC5DbContext db = null;
        public ProducerDAO()
        {
            db = new ShopMVC5DbContext();
        }
        public IEnumerable<Producer> GetAll(string searchString)
        {
            IQueryable<Producer> model = db.Producers;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model;
        }
        public List<Producer> GetAllProducer()
        {
            IQueryable<Producer> producers = db.Producers;
            return db.Producers.ToList();
        }

        public long Create(Producer producer)
        {
            var check = db.Producers.SingleOrDefault(p => p.Name == producer.Name);
            if (check == null)
            {
                db.Producers.Add(producer);
                db.SaveChanges();
                return producer.ID;
            }
            else return -1;
        }
        public int DeleteProducer(long id)
        {
            var check = db.Producers.Find(id);
            if (check == null) return -1;
            else {
                try
                {
                    var products = db.Products.Where(pro => pro.ProducerID == id).ToList();
                    foreach (var pro in products) { db.Products.Remove(pro); };
                    //var producer = db.Producers.Include()
                    db.Producers.Remove(check);
                    db.SaveChanges();
                    return 1;
                }
                catch(Exception)
                { return -1; }
             
            };
        }

        public long Edit(long id, string name, string metatitle)
        {
            var check = db.Producers.SingleOrDefault(p => p.Name == name);
            if (check == null)
            {
                var producer = db.Producers.Find(id);
                producer.Name = name;
                producer.MetaTitle = metatitle;
                db.Entry(producer).State = EntityState.Modified;
                db.SaveChanges();
                return producer.ID;
            }
            return -1;
        }
    }
}