using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dao.Question
{
    public class QuestionDtoResult
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public string TestType { get; set; }

        public string QuestionLevel { get; set; }

        public string Subject { get; set; }

        public string Answer { get; set; }
        
    }
}
