using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lawfirm.Areas.Admin.Models.Question
{
    public class CauHoiModel
    {
        public CauHoiModel()
        {
            //TestType = new List<SelectListItem>();
            QuestionLevel = new List<SelectListItem>();
            MonHoc = new List<SelectListItem>();
            AnswerRight = new List<SelectListItem>();
            LopHoc = new List<SelectListItem>();
            KichHoat = true;
        }
        public int Id { get; set; }
        public string CauHoi { get; set; }
        public string GhiChu { get; set; }
        public bool KichHoat { get; set; }
        //public int TestTypeId { get; set; }
        //public IList<SelectListItem> TestType { get; set; }
        public int QuestionLevelId { get; set; }
        public IList<SelectListItem> QuestionLevel { get; set; }
        public int MonHocId { get; set; }
        public IList<SelectListItem> MonHoc { get; set; }
        public int LopHocId { get; set; }
        public IList<SelectListItem> LopHoc { get; set; } 
        public int AnswerRightId { get; set; }
        public IList<SelectListItem> AnswerRight { get; set; }
        //anwser
        public string AnswerA { get; set; }
        public string AnwserB { get; set; }
        public string AnwserC { get; set; }
        public string AnwserD { get; set; }
        public string AnwserE { get; set; }
        public string AnwserF { get; set; }
        public string RightYes { get; set; }
        
        public string AnswerRightName { get; set; }
    }
}