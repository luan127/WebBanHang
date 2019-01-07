using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.DAO;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        //load menu main;
        [ChildActionOnly]
        public ActionResult MainMenuPartiview()
        {
            MainMenuModel model = new MainMenuModel();
            var MenuList = model.GetMenuList();
            return PartialView("MainMenuPartiview",MenuList);
        }

    }
}