using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Data.Dao.Users;
using Data.EF;
using Data.Model.Datatablejs;
using lawfirm.Areas.Admin.Models.User;
using Microsoft.AspNet.Identity;

namespace lawfirm.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserDao _userDao;

        public UserController()
        {
            _userDao = new UserDao();
        }
        // GET: Admin/User
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View();
        }
        [HttpPost]
        public ActionResult List(DTParameters request)
        {
            var user = _userDao.GetAllUser();
            var total = user.Count();
            var totalFilter = total;
            if (!string.IsNullOrWhiteSpace(request.Search.Value))
            {
                user = user.Where(d => d.Email.Contains(request.Search.Value)).ToList();
                totalFilter = user.Count();
            }
            var resData = user.Skip(request.Start).Take(request.Length).Select(d=>new UserModel()
            {
                Id = d.Id,
                 Email = d.Email,
                 FullName = d.FullName,
                 Address = d.Address,
                 Phone = d.Phone,
                 RoleName = d.TN_UserType.Name
            }).ToList();
          
            var result = new DTResult<UserModel>()
            {
                data = resData,
                draw = request.Draw,
                recordsFiltered = totalFilter,
                recordsTotal = total
            };
            return Json(result);
        }

        public ActionResult Edit(int id)
        {
            var user = _userDao.GetUserById(id);
            if (user == null)
            {
                return RedirectToAction("List");
            }
            var role = _userDao.GetAllUserType();
         var model = new UserModel()
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                Password = user.Password,
                Address = user.Password,
                Phone = user.Phone,
                RoleId = user.UserTypeId.Value
            };
            role.ForEach(d =>
            {
                if (d.Id == model.RoleId)
                {
                    model.Role.Add(new SelectListItem()
                    {
                        Text = d.Name,
                        Value = d.Id.ToString(),
                        Selected = true
                    });
                }
                else
                {
                    model.Role.Add(new SelectListItem()
                    {
                        Text = d.Name,
                        Value = d.Id.ToString(),
                    });
                }
               
            });
         
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            if (!ModelState.IsValid) return View(model);
            return View();
        }

        public ActionResult Create()
        {
            var role = _userDao.GetAllUserType();
            var model = new UserModel();
            role.ForEach(d =>
            {
                
                    model.Role.Add(new SelectListItem()
                    {
                        Text = d.Name,
                        Value = d.Id.ToString(),
                    });
               
            });
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = new TN_User()
            {
                TimeStamp = new byte[1],
                Email = model.Email,
                UserName = model.Email,
                LowerUserName = model.Email.ToLower(),
                LowerEmail = model.Email.ToLower(),
                CreatedDate = DateTime.Now,
                FullName = model.FullName,
                Phone = model.Phone,
                Address = model.Address,
                Password = Crypto.HashPassword(model.Password),
                UserTypeId = model.RoleId,
                IsActive = true
            };
            _userDao.InsertUser(user);
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var user = _userDao.GetUserById(id);
            if (user == null)
            {
                return RedirectToAction("List");
            }
            var model = new UserModel()
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                Password = user.Password,
                Address = user.Password,
                Phone = user.Phone,
                RoleName = user.TN_UserType.Name
            };
            return View(model);
        }
    }
}