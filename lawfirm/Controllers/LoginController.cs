using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using Data.Dao.Test;
using Data.Dao.Users;
using Data.EF;
using lawfirm.Common;
using lawfirm.Models.Home;
using lawfirm.Models.Login;

namespace lawfirm.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserDao _userDao;
        private readonly Message _message;

        public LoginController()
        {
            _userDao = new UserDao();
            _message = new Message();
        }
        // GET: Login
        public ActionResult Index()
        {
            var session = Session[CommonConstants.USER_SESSION];
            if (session != null)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new LoginRegisterModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginRegisterModel model)
        {
            if (string.IsNullOrWhiteSpace(model.LoginModel?.Email) || string.IsNullOrWhiteSpace(model.LoginModel.Password))
            {
                return View("Index");
            }
            var res = _userDao.GetUserByEmail(model.LoginModel.Email);
            if (res == null)
            {
                ModelState.AddModelError("", "Lỗi email đã tồn tại");
                return View("Index", model);
            }
            if (!Crypto.VerifyHashedPassword(res.Password, model.LoginModel.Password))
            {
                ModelState.AddModelError("", "Lỗi mật khẩu không chính xác");
                return View("Index", model);
            }
     
            //authentication
            FormsAuthentication.SetAuthCookie(res.UserName, false);
            var authTicket = new FormsAuthenticationTicket(1,res.Email, DateTime.Now, DateTime.Now.AddMinutes(120), false, res.TN_UserType.SystemName);
            var encryptedTicked = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicked);
            HttpContext.Response.Cookies.Add(authCookie);
            //set session
            var modelHome = new HomeUserModel()
            {
                Email = res.Email,
                Id = res.Id
            };
            Session.Add(CommonConstants.USER_SESSION,modelHome);
            Session.Timeout = 120;

            return RedirectToAction("Index","Home");
        }
        public ActionResult Logout()
        {

            var session = Session[CommonConstants.USER_SESSION];
            if (session != null)
            {
                Session.Clear();
                FormsAuthentication.SignOut();
            }
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(LoginRegisterModel model)
        {
            if (model.RegisterModel == null)
            {
                return View("Index", model);
            }
            var user = new TN_User()
            {
                TimeStamp = new byte[1],
                Email = model.RegisterModel.Email,
                UserName = model.RegisterModel.Email,
                LowerUserName = model.RegisterModel.Email.ToLower(),
                LowerEmail = model.RegisterModel.Email.ToLower(),
                CreatedDate = DateTime.Now,
                //FullName = model.RegisterModel.FullName,
                FullName = "Truong Tan Dat",
                Phone = model.RegisterModel.Phone,
                Address = model.RegisterModel.Address,
                Password = Crypto.HashPassword(model.RegisterModel.Password),
                //UserTypeId = model.RegisterModel.RoleId,
                UserTypeId = 1,
                IsActive = true
            };
            _userDao.InsertUser(user);
            _message.SendMessageMail("sdflka","School web","dattt@fsw.vn", "dattt@fsw.vn","Dang ky thanh cong");
            return RedirectToAction("Index","Home");
        }

        public ActionResult _Login()
        {
            var model = new Login();
            return View(model);
        }

        [HttpPost]
        public ActionResult GetUser()
        {
            var session = Session[CommonConstants.USER_SESSION] as HomeUserModel;
            if (session == null)
            {
                return null;
            }
            var user = _userDao.GetUserById(session.Id);
            return  Json(new {FullName = user.FullName, Email = user.Email, Note = user.Note});
        }
    }
}