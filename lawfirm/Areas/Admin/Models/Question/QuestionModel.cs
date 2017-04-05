using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lawfirm.Areas.Admin.Models.Question
{
    public class QuestionModel
    {
        public QuestionModel()
        {
            TestType = new List<SelectListItem>();
            QuestionLevel = new List<SelectListItem>();
            Subject = new List<SelectListItem>();
            AnswerRight = new List<SelectListItem>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string TestTypeName { get; set; }
        public IList<SelectListItem>  TestType { get; set; }
        public string QuestionLevelName { get; set; }
        public IList<SelectListItem> QuestionLevel { get; set; } 
        public string SubjectName { get; set; }
        public IList<SelectListItem> Subject { get; set; } 
        public string AnswerRightName { get; set; }
        public IList<SelectListItem> AnswerRight { get; set; } 
        //anwser
        public string AnswerA { get; set; }
        public string AnwserB { get; set; }
        public string AnwserC { get; set; }
        public string AnwserD { get; set; }
        public string AnwserE { get; set; }
        public string AnwserF { get; set; }
        public string RightYes { get; set; }
    }
}