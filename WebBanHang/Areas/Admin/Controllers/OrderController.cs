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
using PagedList;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private ShopMVC5DbContext db = new ShopMVC5DbContext();
        private OrderDAO orderDAO= new OrderDAO();

        [HttpGet]
        // GET: Admin/Order
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

            var orders = orderDAO.GetAllOrder(searchStr);//lay ra product

            ViewBag.CurrentFilter = searchStr;
            int pageNumber = (page ?? 1);
            int pagesize = 2;
            return View(orders.ToPagedList(pageNumber, pagesize));
        }
        // GET: Admin/Order/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            var orderDetails = orderDAO.GetDetails(order);
            return View(orderDetails.ToList());
        }

        // GET: Admin/Order/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "ID", "Username");
            return View();
        }

        // POST: Admin/Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,ShipName,ShipPhone,ShipAddress,ShipCreateDate,ShipEmail,Status,TotalPrice")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "ID", "Username", order.UserID);
            return View(order);
        }

        // GET: Admin/Order/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "ID", "Username", order.UserID);
            return View(order);
        }

        // POST: Admin/Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,ShipName,ShipPhone,ShipAddress,ShipCreateDate,ShipEmail,Status,TotalPrice")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "ID", "Username", order.UserID);
            return View(order);
        }

        // POST: Admin/Order/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Delete(long id)
        {
            try
            {
                Order order = db.Orders.Find(id);
                db.Orders.Remove(order);
                db.SaveChanges();
                return Json(new { status = true });
            }
            catch(Exception)
            {
                return Json(new { status = false });
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
