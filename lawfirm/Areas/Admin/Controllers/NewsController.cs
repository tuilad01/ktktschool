using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Data.Dao.News;
using Data.EF;
using Data.Model.Datatablejs;
using lawfirm.Areas.Admin.Models.News;

namespace lawfirm.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NewsController : Controller
    {
        private readonly NewDao _newDao;

        public NewsController()
        {
            _newDao = new NewDao();
        }
        // GET: Admin/News
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
            var res = _newDao.SearchNews(request.Start, request.Length, request.Draw, request.Search.Value);
            return Json(res);
        }

        public ActionResult Create()
        {
            var model = new NewModel
            {
                NewType = _newDao.GetAllLoaiTinTuc().Select(d => new SelectListItem()
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(NewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.NewType = _newDao.GetAllLoaiTinTuc().Select(d => new SelectListItem()
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).ToList();
                return View(model);
            }
      
            if (model.Image == null || model.Image.ContentLength <= 0
                && (Path.GetExtension(model.Image.FileName)?.ToLower() != ".jpg"
                    || Path.GetExtension(model.Image.FileName)?.ToLower() != ".png"
                    || Path.GetExtension(model.Image.FileName)?.ToLower() != ".gif"
                    || Path.GetExtension(model.Image.FileName)?.ToLower() != ".jpeg"))
            {
                model.NewType = _newDao.GetAllLoaiTinTuc().Select(d => new SelectListItem()
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).ToList();
                return View(model);
            }
            //var path = Path.Combine(Server.MapPath("~/Content/Upload/images"), model.Image.FileName);
            //model.Image.SaveAs(path);
            using (MemoryStream ms = new MemoryStream())
            {
                model.Image.InputStream.CopyTo(ms);
                byte[] array = ms.GetBuffer();
                _newDao.InsertNew(new TN_TinTuc()
                {
                    CreateAt = DateTime.Now,
                    Description = model.Detail,
                    Image = array,
                    IsActive = model.IsActive,
                    Short = model.Short,
                    Title = model.Title,
                    TypeId = model.NewTypeId
                });
            }

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var news = _newDao.GetTinTucById(id);
            if(news == null) return RedirectToAction("List");
            var model = new NewModel()
            {
                Id = news.Id,
                Short = news.Short,
                Title = news.Title,
                IsActive = news.IsActive ?? false,
                NewTypeId = news.TypeId ?? 0,
                Detail = news.Description
            };
            _newDao.GetAllLoaiTinTuc().ForEach(d =>
            {
                if (d.Id == model.NewTypeId)
                {
                    model.NewType.Add(new SelectListItem()
                    {
                        Value = d.Id.ToString(),
                        Text = d.Name,
                        Selected = true
                    });
                }
                else
                {
                    model.NewType.Add(new SelectListItem()
                    {
                        Value = d.Id.ToString(),
                        Text = d.Name
                    });
                }
            });

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(NewModel model)
        {
            var news = _newDao.GetTinTucById(model.Id);
            if (news == null) return RedirectToAction("List");
            if (!ModelState.IsValid)
            {
                model.NewType = _newDao.GetAllLoaiTinTuc().Select(d => new SelectListItem()
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).ToList();
                return View(model);
            }
            news.Description = model.Detail;
            news.Title = model.Title;
            news.IsActive = model.IsActive;
            news.Short = model.Short;
            news.TypeId = model.NewTypeId;
            
            _newDao.UpdateNew(news);
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var news = _newDao.GetTinTucById(id);
            if (news == null) return RedirectToAction("List");

            var model = new NewModel()
            {
                Id = news.Id,
                IsActive = news.IsActive?? false,
                Short = news.Short,
                Title = news.Title,
                NewTypeId = news.TypeId ?? 0,
                Detail = news.Description
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(NewModel model)
        {
            var news = _newDao.GetTinTucById(model.Id);
            if (news == null) return RedirectToAction("List");

            _newDao.DeleteNew(news);
            return RedirectToAction("List");
        }

    }
}