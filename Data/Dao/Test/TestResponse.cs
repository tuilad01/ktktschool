using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dao.Test
{
    public class TestResponse
    {
        public int Id { get; set; } 
        /// <summary>
        /// minutes
        /// </summary>
        public int AmountTime { get; set; }
        public List<TestDetail> ListTest { get; set; } 
    }

    public class TestDetail
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public List<Anwser> ListAnwsers { get; set; }
    }

    public class Anwser
    {
        public int Id { get; set; }
        public string AnswerName { get; set; }
        public string Description { get; set; }
        
    }
}
