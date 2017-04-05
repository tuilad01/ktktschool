using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Dao.Test;
using lawfirm.Common;
using lawfirm.Models.Home;
using lawfirm.Models.Practices;
using Microsoft.Owin.Security.Provider;

namespace lawfirm.Controllers
{
    public class PracticesController : Controller
    {
        private readonly TestDao _testDao;

        public PracticesController()
        {
            _testDao = new TestDao();
        }
        // GET: Test
        public ActionResult Index()
        {
            var model = new PracticesListModel();
            return View(model);
        }

        public ActionResult Test(string id)
        {
            var testDao = new TestDao();
            var model = new PracticesListModel();
            var practices = testDao.GetAllTestTypes();
            var testId = 0;
            practices.ForEach(d =>
            {
                if (testId > 0) return;
                var n = testDao.HandleName(d.Name);
                if (id == n) testId = d.Id;
            });
            if (testId == 0)
                if (Request.UrlReferrer != null)
                {
                    return Redirect(Request.UrlReferrer.ToString());
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            var tt = testDao.GeTestTypeById(testId);
            model.TypeId = tt.Id;
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Test(TestRequest request)
        {
            var testDao = new TestDao();
            var tt = testDao.GeTestTypeById(request.Id);
            if (tt == null)
            {
                return Json(new {});
            }
            var model = new PracticesListModel();
            var questionLevel = testDao.GetAllQuestionLevels();
            questionLevel.ForEach(d => model.QuestionLevel.Add(new QuestionLevel()
            {
                Id = d.Id,
                Name = d.Name
            }));
            var mh = testDao.GetAllSubjects();
            switch (tt.TypeId)
            {
                case (int)TestType.Basic:
                    var levelSchool = testDao.GetAllCapHocs();
                    levelSchool.ForEach(d =>
                    {
                        if (d.KichHoat.HasValue && d.KichHoat.Value && d.TN_KhoiLopHoc.Any())
                        {
                            model.LevelSchool.Add(new LevelSchool()
                            {
                                Id = d.Id,
                                Name = d.TenCap
                            });
                        }
                    });

                    var c = testDao.GetAllKhoiLopHocs();
                    c.ForEach(d => model.Class.Add(new Class()
                    {
                        Id = d.Id,
                        Name = d.TenKhoiLop,
                        LevelSchoolId = d.CapHoc_Id.Value
                    }));
                    var s = testDao.GetAllMonHocs();
                    s.ForEach(d =>
                    {
                        model.Subject.Add(new Subject()
                        {
                            Id = d.Id,
                            Name = d.TenMonHoc,
                            ClassId = d.LopHoc_Id.Value
                        });

                    });

                    mh.ForEach(d =>
                    {
                        if (tt.Id == d.Id)
                        {
                            model.SubjectOther.Add(new Subject()
                            {
                                Name = d.Name,
                                Id = d.Id,
                                ClassId = d.TestTypeId.Value
                            });
                        }
                    });
                    return Json(model);
                case (int)TestType.Other:
                    //TODO: SInh vien chua co mon hoc subjects
                    mh.ForEach(d =>
                    {
                        if (tt.Id == d.TestTypeId)
                        {
                            model.SubjectOther.Add(new Subject()
                            {
                                Name = d.Name,
                                Id = d.Id,
                            });
                        }
                    });
                    return Json(model);
            }
            //if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
            return Json(model);
        }

        [HttpPost]
        public ActionResult GetTest(TestRequest request)
        {
            if (request.MonHocId <= 0) return null;
            
                var user = Session[CommonConstants.USER_SESSION] as HomeUserModel;
                var userId = 0;
                if (user != null)
                {
                    userId = user.Id;
                }
               var res =  _testDao.CreateTest(request.Quantity,request.Time,request.QuestionLevelId,request.MonHocId,request.SubjectId, userId,request.NameTest);
             
            
            return Json(res);
        }

        [HttpPost]
        public ActionResult DoneTest(AnswerModel request)
        {
            if (request.Id <= 0)
            {
                return Json(new {});
            }
            var res = _testDao.DoneTest(request.Id, request.ListAnswers.Select(d => d.AnswerId).ToList());
            return Json(res);
        }


        [HttpPost]
        public ActionResult GetTesting()
        {
            var user = Session[CommonConstants.USER_SESSION] as HomeUserModel;
            var userId = 0;
            if (user == null)
            {
                return Json(new {});
            }
            userId = user.Id;
            var res = _testDao.GetTesting(userId);
            return Json(res);
        }

        public ActionResult ReTest(int id)
        {
            //var user = Session[CommonConstants.USER_SESSION] as HomeUserModel;
            //var userId = 0;
            //if (user == null)
            //{
            //    return RedirectToAction("index", "Home");
            //}
            //userId = user.Id;
            return View();

        }
    }
}