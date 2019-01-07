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
    public class UserController : Controller
    {
        private ShopMVC5DbContext db = new ShopMVC5DbContext();
        private UserDAO userDAO = new UserDAO();

        // GET: Admin/User
        public ActionResult Index(string searchStr)
        {
            return View(userDAO.GetAllUser(searchStr).ToList());
        }
        [HttpGet]
        public ActionResult Index(string searchStr, string currentFilter, int? page)
        {
            if (searchStr != null)
            {
                page = 1;
            }
            else
            {
                searchStr = currentFilter;
            }

            var users = userDAO.GetAllUser(searchStr);//lay ra danh sach user

            ViewBag.CurrentFilter = searchStr;
            int pageNumber = (page ?? 1);
            int pagesize = 20;
            return View(users.ToPagedList(pageNumber, pagesize));
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Username,Password,Name,Address,Email,Genre,BirthDay,Phone, Permission")] User user, HttpPostedFileBase Avatar)
        {
            if (ModelState.IsValid)
            {
                if (Avatar != null && Avatar.ContentLength > 0)
                {
                    string ImageName = user.Username + "Image" + ".png";
                    Avatar.SaveAs(Path.Combine(Server.MapPath("~/Data/Admin/Image/User/"), ImageName));
                    user.Avatar = "~/Data/Admin/Image/User/" + ImageName;
                }
                else user.Avatar = "~/Data/Admin/Image/User/UserDefault.png";
                var result=userDAO.Create(user);
                if(result!=-1)
                {
                    TempData["Success"] = "Thêm tài khoản thành công!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Thêm tài khoản thất bại!";
                    return View(user);
                }               
            }
            return View(user);
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Username,Name,Address,Email,Genre,BirthDay,Phone, Permission")] User user, HttpPostedFileBase Avatar)
        {
            if (ModelState.IsValid)
            {
                if (Avatar != null && Avatar.ContentLength > 0)
                {
                    string ImageName = user.Username + "Image" + ".png";
                    Avatar.SaveAs(Path.Combine(Server.MapPath("~/Data/Admin/Image/User/"), ImageName));
                    user.Avatar = "~/Data/Admin/Image/User/" + ImageName;
                }
                var result = userDAO.Edit(user);
                if (result ==true)
                {
                    TempData["Success"] = "Cập nhật tài khoản thành công!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Cập nhật tài khoản thất bại!";
                    return View(user);
                }
            }
            return View(user);
        }



        // POST: Admin/User/Delete/5
        [HttpPost]
        public JsonResult Delete(long id)
        {
            var result=userDAO.Delete(id);
            if(result==false) return Json(new { message = "Bạn không thể xóa tài khoản này!", status=0 });
            return Json(new { message = "Xóa thành công", status=1 });
        }
        [HttpPost]
        public JsonResult Block(long id)
        {
            string message = "";
            int status = 0;
            int result = userDAO.ChangeBlock(id);
            if (result == 0) { message = "Đã cho phép!"; status = 0; }
            else if (result == 1) { message = "Đã block thành công!";status = 1; }
            else message = "Đã có lỗi sảy ra!";

            return Json(new { message = message, status= status});
        }
      
        /// <summary>
        /// changPassword
        /// </summary>
        [HttpPost]
        public JsonResult ChangePassword(long id, string oldPassword, string newPassword)
        {
            var result = userDAO.ChangePass(id, oldPassword, newPassword);
            return Json(new { result = result });
        }
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //thêm ảnh cho User
        private void AddUserImage(HttpPostedFileBase Image, User user)
        {
            
        }
    }
}
