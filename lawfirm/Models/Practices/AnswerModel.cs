using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lawfirm.Models.Practices
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public List<QuestionAnswer> ListAnswers { get; set; }
    }

    public class QuestionAnswer
    {
        public int Id { get; set; }
        public int AnswerId { get; set; }
    }
}