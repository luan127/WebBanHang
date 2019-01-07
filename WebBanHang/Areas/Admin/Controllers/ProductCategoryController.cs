using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.DAO;
using WebBanHang.Models.EF;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        private ShopMVC5DbContext db = new ShopMVC5DbContext();
        private ProductCategoryDAO proCategoryDAO = new ProductCategoryDAO();

        // GET: Admin/ProductCategory
        public ActionResult Index()
        {
            return View(db.ProductCategories.ToList());
        }

        // GET: Admin/ProductCategory/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = db.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // GET: Admin/ProductCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create(string name, string metatitle)
        {
            var result = proCategoryDAO.Create(name, metatitle);
            if (result > 0)
            {
                TempData["Success"] = "Thêm loại hàng thành công!";
                return Json(new { status = "Thêm thành công!" });
            }
                
            else
            {
                TempData["Error"] = "Thêm loại hàng không thành công!";
                return Json(new { status = "Thêm không thành công!" });
            }

                
        }


        // POST: Admin/ProductCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public JsonResult Edit(long id, string name, string metatitle)
        {
            var result = proCategoryDAO.Edit(id, name, metatitle);
            if (result > 0)
            {
                TempData["Success"] = "Cập nhật loại hàng thành công!";
                return Json(new { status = "Cập nhật thành công!" });
            }

            else
            {
                TempData["Error"] = "Cập nhật loại hàng không thành công!";
                return Json(new { status = "Cập nhật không thành công!" });
            }
        }

        // POST: Admin/ProductCategory/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Delete(long id)
        {
            ProductCategory productCategory = db.ProductCategories.Find(id);
            if(productCategory!=null)
            {
                try
                {
                    var products = db.Products.Where(pro => pro.ProductCategoryID == id);
                    foreach(var pro in products)
                    {
                        db.Products.Remove(pro);
                    }
                    db.ProductCategories.Remove(productCategory);
                    db.SaveChanges();
                    return Json(new { status = true });
                }
                catch(Exception)
                {
                    return Json(new { status = false });
                }
                
            }
            else return Json(new { status = false });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
