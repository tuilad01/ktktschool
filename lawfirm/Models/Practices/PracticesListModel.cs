using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lawfirm.Models.Practices
{
    public class PracticesListModel
    {
        public PracticesListModel()
        {
            Class = new List<Class>();
            Subject = new List<Subject>();
            SubjectOther = new List<Subject>();
            QuestionLevel = new List<QuestionLevel>();
            LevelSchool = new List<LevelSchool>();
        }
        public int TypeId { get; set; }
        public int ClassId { get; set; }
        public IList<Class>  Class { get; set; }

        public int SubjectId { get; set; }
        public IList<Subject> Subject { get; set; } 
        public IList<Subject> SubjectOther { get; set; } 

        /// <summary>
        /// Cấp độ câu hỏi: giỏi , khá , trung bình, yếu, kém
        /// </summary>
        public int QuestionLevelId { get; set; }
        public IList<QuestionLevel> QuestionLevel { get; set; } 

        /// <summary>
        /// cấp độ học: tiểu học, đại học, phổ thông
        /// </summary>
        public int LevelSchoolId { get; set; }
        public IList<LevelSchool> LevelSchool { get; set; } 
    }

    public class QuestionLevel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class LevelSchool
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LevelSchoolId { get; set; }
    }

    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }

    }
}