using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Areas.Admin.Models;
using WebBanHang.Constant;
using WebBanHang.DAO;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private UserDAO userDAO = new UserDAO();
        private UserLogin userLogin = new UserLogin();
        // GET: Admin/Login
        public ActionResult Index()
        {

            if (Request.Cookies["UserNameAdmin"] != null)
            {
                string cookiesUserName = Request.Cookies["UserNameAdmin"].Value;
                var user = userDAO.getUserByUserName(cookiesUserName);
                if (user != null)
                {
                    userLogin.UserName = user.Username;
                    userLogin.Password = user.Password;
                    userLogin.Permission = (int)user.Permission;
                    Session.Add("Avatar", user.Avatar);
                    Session["USER_SESSION"] = userLogin;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = ("UserName, Password, RememberMe"))] LoginModel login)
        {
            if (ModelState.IsValid)
            {
                int result = userDAO.UserLogin(login);
                if (result == 1)
                {
                    var user = userDAO.getUserByUserName(login.Username);
                    if (login.RememberMe)
                    {
                        Response.Cookies["UserNameAdmin"].Value = login.Username;
                        Response.Cookies["UserNameAdmin"].Expires = DateTime.Now.AddDays(3);

                    }
                    //gan vao session
                    userLogin.UserName = user.Username;
                    userLogin.Password = user.Password;
                    userLogin.Permission = (int)user.Permission;
                    Session.Add("Permission", userLogin.Permission);
                    Session.Add("Avatar", user.Avatar);
                    Session.Add("UserName", user.Username);
                    Session.Add("ID", user.ID);
                    Session["USER_SESSION"] = userLogin;

                    return RedirectToAction("Index", "Home");
                }
                else if (result == -1)
                {
                    TempData["Error"] = "Tài khoản không tồn tại!";
                }
                else if (result == 2)
                {
                    TempData["Error"] = "Tài khoản đã bị vô hiệu hóa!";
                }
                else if (result == 3)
                {
                    TempData["Error"] = "Sai mật khẩu!";
                }
                else
                {
                    TempData["Error"] = "Đăng nhập không thành công!";//co the redirection sang user
                }
                return View(login);
            }
            return View(login);
        }
       // [HttpPost]
        public ActionResult Logout()
        {
            Session["Permission"]=null;
            Session["Avatar"] = null;
            Session["ID"] = null;
            Session["USER_SESSION"] = null;
            Session["UserName"] = null;
            if (Response.Cookies["UserNameAdmin"] != null)
            {
                Response.Cookies["UserNameAdmin"].Expires = DateTime.Now.AddDays(-1);
            }

            return View("Index");
        }
    }
}