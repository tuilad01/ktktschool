using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Data.Dao.Question;
using Data.Dao.Test;
using Data.EF;
using Data.Model.Datatablejs;
using lawfirm.Areas.Admin.Models.Question;

namespace lawfirm.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QuestionController : Controller
    {
        private readonly QuestionDao _questionDao;
        private readonly TestDao _testDao;

        public QuestionController()
        {
            _questionDao = new QuestionDao();
            _testDao = new TestDao();
        }
        // GET: Admin/Question
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
            var res = _questionDao.SearchQuestionses(request.Start, request.Length, request.Draw, request.Search.Value);
            return Json(res);
        }

        public ActionResult Create()
        {
            var model = new QuestionModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(QuestionModel model)
        {
            return View();
        }
        public ActionResult CauHoiList()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CauHoiList(DTParameters request)
        {
            var res = _questionDao.SearchCauHoi(request.Start, request.Length, request.Draw, request.Search.Value);
            return Json(res);
        }

        public ActionResult CauHoiCreate()
        {
            var model = new CauHoiModel();
            model = PrepareCauHoiModel(model);

            return View(model);
        }
        [HttpPost]
        public ActionResult CauHoiCreate(CauHoiModel model, bool createContinue)
        {
            var cauhoi = new TN_CauHoi()
            {
                TenCauHoi = model.CauHoi,
                GhiChu = model.GhiChu,
                KichHoat = model.KichHoat,
                MonHoc_Id = model.MonHocId,
                QuestionLevelId = model.QuestionLevelId,
                TestTypeId = (int)TestType.Basic,
            };
            if (model.RightYes != null)
            {
                switch (model.RightYes)
                {
                    case "Right":
                        _testDao.InsertCauHoiAndDapAn(new List<TN_CauHoi_DapAn>()
                        {
                            new TN_CauHoi_DapAn() {TN_CauHoi = cauhoi, DapAn_Id = (int) DapAn.Dung, IsDung = true},
                            new TN_CauHoi_DapAn() {TN_CauHoi = cauhoi, DapAn_Id = (int) DapAn.Sai},
                        });
                        break;
                    case "Wrong":
                        _testDao.InsertCauHoiAndDapAn(new List<TN_CauHoi_DapAn>()
                        {
                            new TN_CauHoi_DapAn() {TN_CauHoi = cauhoi, DapAn_Id = (int) DapAn.Dung},
                            new TN_CauHoi_DapAn() {TN_CauHoi = cauhoi, DapAn_Id = (int) DapAn.Sai, IsDung = true},
                        });
                        break;
                    case "Yes":
                        _testDao.InsertCauHoiAndDapAn(new List<TN_CauHoi_DapAn>()
                        {
                            new TN_CauHoi_DapAn() {TN_CauHoi = cauhoi, DapAn_Id = (int) DapAn.Co, IsDung = true},
                            new TN_CauHoi_DapAn() {TN_CauHoi = cauhoi, DapAn_Id = (int) DapAn.Khong},
                        });
                        break;
                    case "No":
                        _testDao.InsertCauHoiAndDapAn(new List<TN_CauHoi_DapAn>()
                        {
                            new TN_CauHoi_DapAn() {TN_CauHoi = cauhoi, DapAn_Id = (int) DapAn.Co},
                            new TN_CauHoi_DapAn() {TN_CauHoi = cauhoi, DapAn_Id = (int) DapAn.Khong, IsDung = true},
                        });
                        break;
                }
            }
            else
            {
                var cauhoiDapAn = new List<TN_CauHoi_DapAn>();
                if (!string.IsNullOrWhiteSpace(model.AnswerA))
                {
                    cauhoiDapAn.Add(new TN_CauHoi_DapAn()
                    {
                        TN_CauHoi = cauhoi,
                        DapAn_Id = (int)DapAn.A,
                        GhiChu = model.AnswerA,
                        IsDung = (int)DapAn.A == model.AnswerRightId
                    });
                }
                if (!string.IsNullOrWhiteSpace(model.AnwserB))
                {
                    cauhoiDapAn.Add(new TN_CauHoi_DapAn()
                    {
                        TN_CauHoi = cauhoi,
                        DapAn_Id = (int)DapAn.B,
                        GhiChu = model.AnwserB,
                        IsDung = (int)DapAn.B == model.AnswerRightId
                    });
                }
                if (!string.IsNullOrWhiteSpace(model.AnwserC))
                {
                    cauhoiDapAn.Add(new TN_CauHoi_DapAn()
                    {
                        TN_CauHoi = cauhoi,
                        DapAn_Id = (int)DapAn.C,
                        GhiChu = model.AnwserC,
                        IsDung = (int)DapAn.C == model.AnswerRightId
                    });
                }
                if (!string.IsNullOrWhiteSpace(model.AnwserD))
                {
                    cauhoiDapAn.Add(new TN_CauHoi_DapAn()
                    {
                        TN_CauHoi = cauhoi,
                        DapAn_Id = (int)DapAn.D,
                        GhiChu = model.AnwserD,
                        IsDung = (int)DapAn.D == model.AnswerRightId
                    });
                }
                if (!string.IsNullOrWhiteSpace(model.AnwserE))
                {
                    cauhoiDapAn.Add(new TN_CauHoi_DapAn()
                    {
                        TN_CauHoi = cauhoi,
                        DapAn_Id = (int)DapAn.E,
                        GhiChu = model.AnwserE,
                        IsDung = (int)DapAn.E == model.AnswerRightId
                    });
                }
                if (!string.IsNullOrWhiteSpace(model.AnwserF))
                {
                    cauhoiDapAn.Add(new TN_CauHoi_DapAn()
                    {
                        TN_CauHoi = cauhoi,
                        DapAn_Id = (int)DapAn.F,
                        GhiChu = model.AnwserF,
                        IsDung = (int)DapAn.F == model.AnswerRightId
                    });
                }
                _testDao.InsertCauHoiAndDapAn(cauhoiDapAn);
            }
            if (!createContinue) return RedirectToAction("CauHoiList");

            ModelState.Clear();
            var newModel = new CauHoiModel()
            {
                //LopHocId = cauhoi.
                MonHocId = cauhoi.MonHoc_Id?? 0,
                QuestionLevelId = cauhoi.QuestionLevelId?? 0,
            };
            newModel = PrepareCauHoiModel(newModel);
            

            return View(newModel);
        }

        public ActionResult CauHoiEdit(int id)
        {
            var cauhoi = _testDao.GetCauHoiById(id);
            if(cauhoi == null) return RedirectToAction("CauHoiList");
            
            var model = new CauHoiModel()
            {
                Id = cauhoi.Id,
                CauHoi = cauhoi.TenCauHoi,
                GhiChu = cauhoi.GhiChu,
                KichHoat = cauhoi.KichHoat ?? false,
             
            };
            if (cauhoi.QuestionLevelId.HasValue)
                model.QuestionLevelId = cauhoi.QuestionLevelId.Value;

            if (cauhoi.MonHoc_Id.HasValue)
            {
                model.MonHocId = cauhoi.MonHoc_Id.Value;
                var lhh = _testDao.GetLopHocByMonHoc(cauhoi.MonHoc_Id.Value);
                model.LopHocId = lhh.Id;
            }
              

        
            
            if (cauhoi.TN_CauHoi_DapAn.Any())
            {
                if (cauhoi.TN_CauHoi_DapAn.Any(d => d.DapAn_Id == (int) DapAn.A 
                || d.DapAn_Id == (int)DapAn.B
                || d.DapAn_Id == (int)DapAn.C
                || d.DapAn_Id == (int)DapAn.D
                || d.DapAn_Id == (int)DapAn.E
                || d.DapAn_Id == (int)DapAn.F))
                {
                    var a = cauhoi.TN_CauHoi_DapAn.First(d => d.DapAn_Id == (int) DapAn.A);
                    model.AnswerA = a.GhiChu;
                    var b = cauhoi.TN_CauHoi_DapAn.FirstOrDefault(d => d.DapAn_Id == (int) DapAn.B);
                    model.AnwserB = b?.GhiChu;
                    var c = cauhoi.TN_CauHoi_DapAn.FirstOrDefault(d => d.DapAn_Id == (int) DapAn.C);
                    model.AnwserC = c?.GhiChu;
                    var dd = cauhoi.TN_CauHoi_DapAn.FirstOrDefault(d => d.DapAn_Id == (int) DapAn.D);
                    model.AnwserD = dd?.GhiChu;
                    var e = cauhoi.TN_CauHoi_DapAn.FirstOrDefault(d => d.DapAn_Id == (int) DapAn.E);
                    model.AnwserE = e?.GhiChu;
                    var f = cauhoi.TN_CauHoi_DapAn.FirstOrDefault(d => d.DapAn_Id == (int) DapAn.F);
                    model.AnwserF = f?.GhiChu;
                    var dapanDung = cauhoi.TN_CauHoi_DapAn.FirstOrDefault(d => d.IsDung);
                    model.AnswerRightId = dapanDung?.DapAn_Id ?? a.DapAn_Id;
                }
                else
                {
                    var tnCauHoiDapAn = cauhoi.TN_CauHoi_DapAn.FirstOrDefault(d => d.IsDung);
                    if (tnCauHoiDapAn != null)
                        switch (tnCauHoiDapAn.DapAn_Id)
                        {
                            case (int)DapAn.Dung:
                                model.RightYes = "Right";
                                break;
                            case (int)DapAn.Sai:
                                model.RightYes = "Wrong";
                                break;
                            case (int)DapAn.Co:
                                model.RightYes = "Yes";
                                break;
                            case (int)DapAn.Khong:
                                model.RightYes = "No";
                                break;

                        }
                       
                }
            }

            var questionLevel = _testDao.GetAllQuestionLevels();
            questionLevel.ForEach(d =>
            {
                if (d.Id == model.QuestionLevelId)
                {
                    model.QuestionLevel.Add(new SelectListItem()
                    {
                        Value = d.Id.ToString(),
                        Text = d.Name,
                        Selected = true
                    });
                }
                else
                {
                    model.QuestionLevel.Add(new SelectListItem()
                    {
                        Value = d.Id.ToString(),
                        Text = d.Name,
                    });
                }
            });
           
            var lophoc = _testDao.GetAllKhoiLopHocs();
            lophoc.ForEach(d =>
            {
                if (d.Id == model.LopHocId)
                {
                    model.LopHoc.Add(new SelectListItem()
                    {
                        Value = d.Id.ToString(),
                        Text = d.TenKhoiLop,
                        Selected = true
                    });
                }
                else
                {
                    model.LopHoc.Add(new SelectListItem()
                    {
                        Value = d.Id.ToString(),
                        Text = d.TenKhoiLop,
                    });
                }
            });
            //var lh = lophoc.First();
            //model.LopHocId = lh.Id;
            var monhoc = _testDao.GetMonHocsByLopHoc(model.LopHocId);
            monhoc.ForEach(d =>
            {
                if (d.Id == model.MonHocId)
                {
                    model.MonHoc.Add(new SelectListItem()
                    {
                        Text = d.TenMonHoc,
                        Value = d.Id.ToString(),
                        Selected = true
                    });
                }
                else
                {
                    model.MonHoc.Add(new SelectListItem()
                    {
                        Text = d.TenMonHoc,
                        Value = d.Id.ToString()
                    });
                }
            });

            var dapan = new List<string>() { "A", "B", "C", "D", "E", "F" };
            var numb = 0;
            dapan.ForEach(d =>
            {
                numb++;
                if (numb == model.AnswerRightId)
                {
                    model.AnswerRight.Add(new SelectListItem()
                    {
                        Value = numb.ToString(),
                        Text = d,
                        Selected = true

                    });
                }
                else
                {
                    model.AnswerRight.Add(new SelectListItem()
                    {
                        Value = numb.ToString(),
                        Text = d
                    });
                }

            });

            return View(model);
        }
        [HttpPost]
        public ActionResult CauHoiEdit(CauHoiModel model)
        {
            var cauhoi = _testDao.GetCauHoiById(model.Id);
            if (cauhoi == null) return RedirectToAction("CauHoiList");

            cauhoi.GhiChu = model.GhiChu;
            cauhoi.TenCauHoi = model.CauHoi;
            cauhoi.KichHoat = model.KichHoat;
            cauhoi.QuestionLevelId = model.QuestionLevelId;
            cauhoi.MonHoc_Id = model.MonHocId;
            _testDao.DeleteDapAn(cauhoi.TN_CauHoi_DapAn.ToList());
            if (!string.IsNullOrWhiteSpace(model.RightYes))
            {
                var dapanId = model.RightYes == "Right"
                    ? (int) DapAn.Dung
                    : model.RightYes == "Wrong"
                        ? (int) DapAn.Sai
                        : model.RightYes == "Yes"
                            ? (int) DapAn.Co
                            : (int) DapAn.Khong;
                var dp = cauhoi.TN_CauHoi_DapAn.First(d => d.IsDung);
              
                if (dapanId != dp.DapAn_Id)
                {
                    switch (dapanId)
                    {
                        case (int) DapAn.Dung:
                            _testDao.InsertCauHoiAndDapAn(new List<TN_CauHoi_DapAn>()
                            {
                                new TN_CauHoi_DapAn() {TN_CauHoi = cauhoi, DapAn_Id = (int) DapAn.Dung, IsDung = true},
                                new TN_CauHoi_DapAn() {TN_CauHoi = cauhoi, DapAn_Id = (int) DapAn.Sai},
                            });
                            break;
                        case (int) DapAn.Sai:
                            _testDao.InsertCauHoiAndDapAn(new List<TN_CauHoi_DapAn>()
                            {
                                new TN_CauHoi_DapAn() {TN_CauHoi = cauhoi, DapAn_Id = (int) DapAn.Dung},
                                new TN_CauHoi_DapAn() {TN_CauHoi = cauhoi, DapAn_Id = (int) DapAn.Sai, IsDung = true},
                            });
                            break;
                        case (int) DapAn.Co:
                            _testDao.InsertCauHoiAndDapAn(new List<TN_CauHoi_DapAn>()
                            {
                                new TN_CauHoi_DapAn() {TN_CauHoi = cauhoi, DapAn_Id = (int) DapAn.Co, IsDung = true},
                                new TN_CauHoi_DapAn() {TN_CauHoi = cauhoi, DapAn_Id = (int) DapAn.Khong},
                            });
                            break;
                        case (int) DapAn.Khong:
                            _testDao.InsertCauHoiAndDapAn(new List<TN_CauHoi_DapAn>()
                            {
                                new TN_CauHoi_DapAn() {TN_CauHoi = cauhoi, DapAn_Id = (int) DapAn.Co},
                                new TN_CauHoi_DapAn() {TN_CauHoi = cauhoi, DapAn_Id = (int) DapAn.Khong, IsDung = true},
                            });
                            break;
                    }

                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(model.AnswerA))
                {
                    cauhoi.TN_CauHoi_DapAn.Add(new TN_CauHoi_DapAn()
                    {
                        TN_CauHoi = cauhoi,
                        DapAn_Id = (int)DapAn.A,
                        GhiChu = model.AnswerA,
                        IsDung = (int)DapAn.A == model.AnswerRightId
                    });
                }
                if (!string.IsNullOrWhiteSpace(model.AnwserB))
                {
                    cauhoi.TN_CauHoi_DapAn.Add(new TN_CauHoi_DapAn()
                    {
                        TN_CauHoi = cauhoi,
                        DapAn_Id = (int)DapAn.B,
                        GhiChu = model.AnwserB,
                        IsDung = (int)DapAn.B == model.AnswerRightId
                    });
                }
                if (!string.IsNullOrWhiteSpace(model.AnwserC))
                {
                    cauhoi.TN_CauHoi_DapAn.Add(new TN_CauHoi_DapAn()
                    {
                        TN_CauHoi = cauhoi,
                        DapAn_Id = (int)DapAn.C,
                        GhiChu = model.AnwserC,
                        IsDung = (int)DapAn.C == model.AnswerRightId
                    });
                }
                if (!string.IsNullOrWhiteSpace(model.AnwserD))
                {
                    cauhoi.TN_CauHoi_DapAn.Add(new TN_CauHoi_DapAn()
                    {
                        TN_CauHoi = cauhoi,
                        DapAn_Id = (int)DapAn.D,
                        GhiChu = model.AnwserD,
                        IsDung = (int)DapAn.D == model.AnswerRightId
                    });
                }
                if (!string.IsNullOrWhiteSpace(model.AnwserE))
                {
                    cauhoi.TN_CauHoi_DapAn.Add(new TN_CauHoi_DapAn()
                    {
                        TN_CauHoi = cauhoi,
                        DapAn_Id = (int)DapAn.E,
                        GhiChu = model.AnwserE,
                        IsDung = (int)DapAn.E == model.AnswerRightId
                    });
                }
                if (!string.IsNullOrWhiteSpace(model.AnwserF))
                {
                    cauhoi.TN_CauHoi_DapAn.Add(new TN_CauHoi_DapAn()
                    {
                        TN_CauHoi = cauhoi,
                        DapAn_Id = (int)DapAn.F,
                        GhiChu = model.AnwserF,
                        IsDung = (int)DapAn.F == model.AnswerRightId
                    });
                }
            }
            _testDao.UpdateCauHoi(cauhoi);
            return RedirectToAction("CauHoiList");
        }

        public ActionResult CauHoiDelete(int id)
        {
            var cauhoi = _testDao.GetCauHoiById(id);
            //_testDao.DeleteCauHoi(cauhoi);
            //return RedirectToAction("CauHoiList");
            
            var model = new CauHoiModel()
            {
                Id = cauhoi.Id,
                CauHoi = cauhoi.TenCauHoi,
            };
            var dapan = cauhoi.TN_CauHoi_DapAn.FirstOrDefault(d => d.IsDung);
            if (dapan != null)
            {
                model.AnswerRightName = dapan.DapAn_Id == (int)DapAn.Dung ? "Đúng" 
                    : dapan.DapAn_Id == (int)DapAn.Sai ? "Sai"
                    : dapan.DapAn_Id == (int)DapAn.Khong ? "Không"
                    :dapan.DapAn_Id == (int)DapAn.Co ? "Có"
                    : dapan.TN_DapAn.DapAn + " " + dapan.TN_DapAn.GhiChu;
            }
                
            return View(model);
        }
        [HttpPost]
        public ActionResult CauHoiDelete(CauHoiModel model)
        {
            var cauhoi = _testDao.GetCauHoiById(model.Id);
            if(cauhoi!=null)
                _testDao.DeleteCauHoi(cauhoi);
            return RedirectToAction("CauHoiList");
        }

        [HttpPost]
        public ActionResult GetMonHocByLopHoc(CauHoiModel model)
        {
            var monhoc = _testDao.GetMonHocsByLopHoc(model.LopHocId);
            var mh = monhoc.Select(d => new MonHocModel()
            {
                Id = d.Id,
                Name = d.TenMonHoc
            });
            return Json(mh);
        }

        private CauHoiModel PrepareCauHoiModel(CauHoiModel model)
        {
            var questionLevel = _testDao.GetAllQuestionLevels();
            questionLevel.ForEach(d =>
            {
                if (d.Id == model.QuestionLevelId)
                {
                    model.QuestionLevel.Add(new SelectListItem()
                    {
                        Value = d.Id.ToString(),
                        Text = d.Name,
                        Selected = true
                    });
                }
                else
                {
                    model.QuestionLevel.Add(new SelectListItem()
                    {
                        Value = d.Id.ToString(),
                        Text = d.Name,
                    });
                }
            });

            var lophoc = _testDao.GetAllKhoiLopHocs();
            lophoc.ForEach(d =>
            {
                if (d.Id == model.LopHocId)
                {
                    model.LopHoc.Add(new SelectListItem()
                    {
                        Value = d.Id.ToString(),
                        Text = d.TenKhoiLop,
                        Selected = true
                    });
                }
                else
                {
                    model.LopHoc.Add(new SelectListItem()
                    {
                        Value = d.Id.ToString(),
                        Text = d.TenKhoiLop
                    });
                }
            });
            if (model.LopHocId <= 0 && model.MonHocId > 0)
            {
                var lh = _testDao.GetLopHocByMonHoc(model.MonHocId);
                model.LopHocId = lh.Id;
            }
            if (model.LopHocId <= 0)
            {
                model.LopHocId = 1;
            }
            var monhoc = _testDao.GetMonHocsByLopHoc(model.LopHocId);
            monhoc.ForEach(d =>
            {
                if (d.Id == model.MonHocId)
                {
                    model.MonHoc.Add(new SelectListItem()
                    {
                        Text = d.TenMonHoc,
                        Value = d.Id.ToString(),
                        Selected = true
                    });
                }
                else
                {
                    model.MonHoc.Add(new SelectListItem()
                    {
                        Text = d.TenMonHoc,
                        Value = d.Id.ToString()
                    });
                }
            });
            //hard code
            var dapan = new List<string>() { "A", "B", "C", "D", "E", "F" };
            var numb = 0;
            dapan.ForEach(d =>
            {
                numb++;
                model.AnswerRight.Add(new SelectListItem()
                {
                    Value = numb.ToString(),
                    Text = d
                });
            });

            return model;
        }
    }
}