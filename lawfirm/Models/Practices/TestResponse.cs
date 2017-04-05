using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lawfirm.Models.Practices
{
    public class TestResponse
    {
        public int Id { get; set; }
        public int Minute { get; set; }
        public List<Question> Questions { get; set; }
    }

    public class Answer
    {
        public int Id { get; set; } 
        public int String { get; set; }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Answer> Anwsers { get; set; }
    }
}