using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Dao.News;
using lawfirm.Models.News;

namespace lawfirm.Controllers
{
    public class NewsController : Controller
    {
        private readonly NewDao _newsDao; 
        public NewsController()
        {
            _newsDao = new NewDao();
        }
        // GET: News
        public ActionResult Index(int id = 0)
        {
            var query = _newsDao.GetAllNewsByTypeId(1,5);
            var model = new ListTintucModel
            {
                ListTinTuc = query.News.Select(d => new TintucModel()
                {
                    Id = d.Id,
                    CreatedAt = d.CreatedAt,
                    ImgUrl = d.ImgUrl,
                    Decription = d.Decription,
                    Title = d.Title,
                    Short = d.Short
                }).ToList()
            };

            model.NewsTypeName = _newsDao.GeTinTucLoaiById(1)?.Name;
            return View(model);
        }

        [HttpPost]
        public ActionResult GetAllNews(NewRequest request)
        {
            var res = _newsDao.GetAllNewsByTypeId(request.TypeId,5);
            return Json(res);
        }
        
        public ActionResult Tintuc(int id)
        {
            var query = _newsDao.GetNewsById(id);
            if (query == null) return RedirectToAction("Index");
            var model = new TintucModel()
            {
                Id = query.Id,
                ImgUrl = query.ImgUrl,
                Decription = query.Decription,
                Title = query.Title,
                Short = query.Short,
                CreatedAt = query.CreatedAt
            };
            return View(model);
        }
    }
}