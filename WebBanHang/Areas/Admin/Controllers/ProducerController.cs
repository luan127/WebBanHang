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
    public class ProducerController : Controller
    {
        private ShopMVC5DbContext db = new ShopMVC5DbContext();
        private ProducerDAO producerDAO = new ProducerDAO();

        // GET: Admin/Producer
        public ActionResult Index()
        {
            
            return View(db.Producers.ToList());
        }
        
        // POST: Admin/Producer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create(string name, string metaTitle)
        {              
            Producer producer = new Producer();
            string status = "";
            try
            {
                producer.Name = name;
                producer.MetaTitle = metaTitle;
                var result = producerDAO.Create(producer);
              
                if (result==-1)
                {
                    TempData["Error"] = "Nhà sản xuất đã tồn tại!";
                    status = "Nhà sản xuất đã tồn tại!";
                    
                }
                else
                {
                    TempData["Success"] = "Thêm nhà sản xuất thành công!";
                    status = "Thêm nhà sản xuất thành công!";
                }

            }catch
            {
                TempData["Error"] = "Thêm nhà sản xuất không thành công!";
                status = "Thêm nhà sản xuất không thành công!";
            }
            return Json(new { status = status });
        }

        

        // POST: Admin/Producer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Edit(long id, string name, string metatitle)
        {
            var result = producerDAO.Edit(id, name, metatitle);
            if (result > 0)
            {
                TempData["Success"] = "Cập nhật nhà sản xuất thành công!";
                return Json(new { status = "Cập nhật nhà sản xuất thành công!" });
            } 
            else
            {
                TempData["Error"] = "Cập nhật nhà sản xuất thất bại!";
                return Json(new { status = "Cập nhật nhà sản xuất thất bại!" });
            }
        }
               

        // POST: Admin/Producer/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var result = producerDAO.DeleteProducer((int)id);
                if (result==1)
                {
                    //TempData["Success"] = "Xóa nhà sản xuất thành công!";
                    return Json(new { status = true });
                }
                else
                {
                    //TempData["Error"] = "Xóa nhà sản xuất thất bại!";
                    return Json(new { status = false });
                }               
            }
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
