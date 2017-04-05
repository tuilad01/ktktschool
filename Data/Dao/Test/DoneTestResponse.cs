using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dao.Test
{
    public class DoneTestResponse
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public int NumberRight { get; set; } 
        public int NumberQuestion { get; set; }
        public float ResultPrecent { get; set; }
        public string StartAt { get; set; }
        public string EndAt { get; set; }
    }
}
