using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Dao.Test;
using Data.Dao.Users;
using lawfirm.Areas.Admin.Models.Login;
using lawfirm.Models.Home;
using System.Web.Security;
using System.Web.Helpers;
using lawfirm.Common;

namespace lawfirm.Areas.Admin.Controllers
{

    public class LoginController : Controller
    {
        private readonly UserDao _userDao;

        public LoginController()
        {
            _userDao = new UserDao();
        }
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (string.IsNullOrWhiteSpace(model?.Email) || string.IsNullOrWhiteSpace(model.Password))
            {
                return View("Index");
            }
            var res = _userDao.GetUserByEmail(model.Email);
            if (res == null)
            {
                ModelState.AddModelError("", "Lỗi email đã tồn tại");
                return View("Index", model);
            }
            if (!Crypto.VerifyHashedPassword(res.Password, model.Password))
            {
                ModelState.AddModelError("", "Lỗi mật khẩu không chính xác");
                return View("Index", model);
            }
   
            //authentication
            FormsAuthentication.SetAuthCookie(res.UserName, false);
            var authTicket = new FormsAuthenticationTicket(1, res.Email, DateTime.Now, DateTime.Now.AddMinutes(120), false, res.TN_UserType.SystemName);
            var encryptedTicked = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicked);
            HttpContext.Response.Cookies.Add(authCookie);
            var modelHome = new HomeUserModel()
            {
                Email = res.Email,
                Id = res.Id
            };
            Session.Add(CommonConstants.USER_SESSION, modelHome);
            Session.Timeout = 120;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            var session = Session[CommonConstants.USER_SESSION];
            if (session != null)
            {
                Session.Clear();
                FormsAuthentication.SignOut();
            }
            return RedirectToAction("Login", "Login");
        }
        // GET: Admin/Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
