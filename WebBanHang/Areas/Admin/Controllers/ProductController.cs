using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.DAO;
using WebBanHang.Models.EF;
using PagedList;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private ShopMVC5DbContext db = new ShopMVC5DbContext();
        private ProductDAO proDAO = new ProductDAO();
        private SaleDAO saleDAO = new SaleDAO();

        // GET: Admin/Product
        public ActionResult Index(string searchStr, string currentFilter, int? page, string searchProducer)
        {
            if (searchStr!=null)
            {
                page = 1;
            }
            else
            {
                searchStr = currentFilter;
            }

            var products = proDAO.GetAllProduct(searchStr, searchProducer);//lay ra product

            ViewBag.CurrentFilter = searchStr;
            int pageNumber = (page ?? 1);
            int pagesize = 9;
            return View(products.ToPagedList(pageNumber, pagesize));
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Include(p=>p.Sales).SingleOrDefault(p=>p.ID==id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.ProducerID = new SelectList(db.Producers, "ID", "Name");
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "ID", "Name");
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Code,MetaTitle,Price,Description,Quantity,Detail,ProducerID,ProductCategoryID")] Product product,
            List<HttpPostedFileBase> listImages, HttpPostedFileBase primaryImage, int Discount, DateTime? BeginDate, DateTime? EndDate)
        {
            ViewBag.ProducerID = new SelectList(db.Producers, "ID", "Name");
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "ID", "Name");
            if (ModelState.IsValid)
            {               
                var result = proDAO.Create(product);
                //if (Discount > 0)
                //{ 
                    
                //    BeginDate = (BeginDate==null ? BeginDate = DateTime.Now : BeginDate);
                //    EndDate = EndDate == null ? ((DateTime)BeginDate).AddDays(30) : EndDate;
                //    var sale = new Sale { Discount = Discount, BeginDate = (DateTime)BeginDate, EndDate = (DateTime)EndDate, ProductID = product.ID };
                //    db.Sales.Add(sale);
                //    db.SaveChanges();
                //}
                if (result == -1)
                {
                    TempData["Error"] = "Sản phẩm đã tồn tại!";
                }
                else
                {
                    InsertImage(listImages, primaryImage, product);
                    saleDAO.Create(product, Discount, BeginDate, EndDate);
                    TempData["Success"] = "Thêm sản thành công!";
                }
                return View();
            }
            TempData["Error"] = "Thêm sản không thành công!";
            return View(product);
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProducerID = new SelectList(db.Producers, "ID", "Name", product.ProducerID);
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "ID", "Name", product.ProductCategoryID);
            return View(product);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Code,MetaTitle,Price,Description,Quantity,Detail,IsHot,IsNew,Status,ProducerID,ProductCategoryID")] Product product,
            List<HttpPostedFileBase> listImages, HttpPostedFileBase primaryImage)
        {
            if (ModelState.IsValid)
            {                
                bool result = proDAO.Update(product);
                if (result)
                {
                    /////cần cập nhật image and sale
                    TempData["Success"] = "Cập nhật thành công!";
                }

                else TempData["Erorr"] = "Cập nhật không thành công!";
            }
            ViewBag.ProducerID = new SelectList(db.Producers, "ID", "Name", product.ProducerID);
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "ID", "Name", product.ProductCategoryID);
            var pro = db.Products.Include(p=>p.Producer).Include(p=>p.ProductCategory).SingleOrDefault(p=>p.ID==product.ID);
            return View("Details", pro);
        }
        /// Product disable
        /// 
        [HttpGet]
        public ActionResult DisableProducts(string searchStr, string currentFilter, int? page)
        {
            if (searchStr != null)
            {
                page = 1;
            }
            else
            {
                searchStr = currentFilter;
            }

            var products = proDAO.GetDisableProduct(searchStr);//lay ra product

            ViewBag.CurrentFilter = searchStr;
            int pageNumber = (page ?? 1);
            int pagesize = 2;
            return View(products.ToPagedList(pageNumber, pagesize));
        }
        [HttpPost]
        public JsonResult UnDisableProduct(int id, bool conf)
        {
            if(conf==true)
            {
                Product product = db.Products.Find(id);
                product.Status = true;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { ok="Khôi phục sản phẩm thành công!" });
            }
            else return Json(new { cancel = "Hủy option" });
        }

       
       
        // POST: Admin/Product/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Disable(int id, bool conf)
        {
            if (conf == true)
            {
                Product product = db.Products.Find(id);
                product.Status = false;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { ok = "Xóa thành công!" });
            }
            else return Json(new { cancel = "Hủy option" });
           
        }
        [HttpPost]
        public JsonResult DeleteProduct(long id)
        {
            var result = proDAO.DeleteProduct(id);
            if (result == 1) return Json(new { ok = "Xóa thành công!" });
            else return Json(new { cancel = "Xóa không thành công!" });
        }
        [HttpGet]
        public ActionResult Test(string searchName, string searchProducer, int? searchPrice, int? searchQuantity)
        {
            //IQueryable<Product> products = db.Products.Include(p=>p.Producer);
            //if(!String.IsNullOrEmpty(searchName))
            //{
            //    products = products.Where(p => p.Name.Contains(searchName));
            //}
            //if (!String.IsNullOrEmpty(searchProducer))
            //{
            //    products = products.Where(p => p.Producer.Name.Contains(searchProducer));
            //}
            //return View(products);

            IQueryable<Product> products = (from p in db.Products select p);
            {
                products = (from p in db.Products where p.Name == searchName 
                            && p.Quantity== searchQuantity && p.Price==searchPrice 
                            && p.Producer.Name==searchProducer
                            select p );
            }
            return View(products);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //////test
        public ActionResult Test()
        {
            return View("test");
        }
        ///InsertImage///
        public void InsertImage(List<HttpPostedFileBase> listImages, HttpPostedFileBase primaryImage, Product product)
        {
            if (primaryImage != null && primaryImage.ContentLength > 0)
            {
                string ImageName = product.MetaTitle + "Image" + ".png";
                primaryImage.SaveAs(Path.Combine(Server.MapPath("~/Data/Admin/Image/Product/"), ImageName));
                var image = new Image { ProductID = product.ID, Src = "~/Data/Admin/Image/Product/" + ImageName };
                db.Images.Add(image);
                db.SaveChanges();
            }
            if (listImages != null)
            {
                int a = 1;
                foreach (var i in listImages)
                {

                    if (i != null && i.ContentLength > 0)
                    {

                        string ImageName = product.MetaTitle + "Image" + a.ToString() + ".png";
                        a++;
                        i.SaveAs(Path.Combine(Server.MapPath("~/Data/Admin/Image/Product/"), ImageName));
                        var image = new Image { ProductID = product.ID, Src = "~/Data/Admin/Image/Product/" + ImageName };
                        db.Images.Add(image);
                        db.SaveChanges();
                    }
                }
            }

        }
    }
}
