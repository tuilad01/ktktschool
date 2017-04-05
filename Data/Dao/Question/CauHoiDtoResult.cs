using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dao.Question
{
    public class CauHoiDtoResult
    {
        public int Id { get; set; }

        public string TenCauHoi { get; set; }

        public string GhiChu { get; set; }

        public bool KichHoat { get; set; }

        public string TestType { get; set; }

        public string QuestionLevel { get; set; }

        public string MonHoc { get; set; }

        public string DapAn { get; set; }
    }
}
