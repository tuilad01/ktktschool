using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Dao.Test;
using lawfirm.Common;
using lawfirm.Models.Home;

namespace lawfirm.Controllers
{
    public class HomeController : Controller
    {
        private readonly TestDao _testDao;

        public HomeController()
        {
            _testDao = new TestDao();
        }
        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("Page", "HomePage");
        }

        [ChildActionOnly]
        public ActionResult _UserHome()
        {
            var model = new HomeUserModel();
            var session = Session[CommonConstants.USER_SESSION] as HomeUserModel;

            if (session != null)
            {
                model.Email = session.Email;
                model.Id = session.Id;
            }
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult _MenuPractices()
        {
            var menu = _testDao.GetAllTestTypes();
            var model = new List<MenuPractices>();
            menu.ForEach(d =>
            {
                model.Add(new MenuPractices()
                {
                    Name = d.Name,
                    NameUrl = _testDao.HandleName(d.Name)
                });
            });
            return PartialView(model);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [ChildActionOnly]
        public ActionResult _Practices()
        {
            var model = new HomePracticesModel();
            var testDao = new TestDao();
            var test = testDao.GetAllTestTypes();
            var res = test.Select(d=> new Practices()
            {
                Description = d.Description,
                Id = d.Id,
                Name = d.Name,
                TypeId = d.TypeId.Value,
                ImageUrl = d.ImageUrl,
                SystemName = testDao.HandleName(d.Name)
            }).ToList();
            model.ListPracticeses = res;
            return PartialView(model);
        }
    }
}