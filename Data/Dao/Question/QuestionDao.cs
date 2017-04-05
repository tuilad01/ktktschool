using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.EF;
using Data.Model.Datatablejs;

namespace Data.Dao.Question
{
    public class QuestionDao
    {
        private readonly lawfirmDbContext db = null;

        public QuestionDao()
        {
            db = new lawfirmDbContext();
        }

        public DTResult<QuestionDtoResult> SearchQuestionses(int pageIndex, int pageSize, int draw, string name = "")
        {
            var query = db.TN_Questions.ToList();

            //lay tong so rows
            var total = query.Count();
            var totalFilter = total;


            //search theo ten
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(d => d.Name.Contains(name)).ToList();
                totalFilter = query.Count();
            }
            var data = new List<QuestionDtoResult>();
            query.ForEach(d =>
            {
                var q = new QuestionDtoResult()
                {
                    Name = d.Name,
                    Subject = d.TN_Subject.Name,
                    QuestionLevel = d.TN_QuestionLevel.Name,
                    TestType = d.TN_TestType.Name,
                    Active = d.Active ?? false,
                    Description = d.Description,
                };
                var answer = db.TN_Question_DapAn.FirstOrDefault(v => v.Question_Id == d.Id && v.IsDung);
                if (answer != null)
                {
                    q.Answer = answer.TN_DapAn.DapAn + ". " + answer.GhiChu;
                }
                data.Add(q);
            });
            //ket qua tra ve
            var res = new DTResult<QuestionDtoResult>()
            {
                recordsTotal = total,
                draw = draw,
                recordsFiltered = totalFilter,
                data = data.Skip(pageIndex).Take(pageSize).ToList()
            };
            return res;
        }

        public DTResult<CauHoiDtoResult> SearchCauHoi(int pageIndex, int pageSize, int draw, string tencauhoi = "")
        {
            var query = db.TN_CauHoi.ToList();

            //lay tong so rows
            var total = query.Count();
            var totalFilter = total;

            //search theo ten
            if (!string.IsNullOrWhiteSpace(tencauhoi))
            {
                query = query.Where(d => d.TenCauHoi.Contains(tencauhoi)).ToList();
                totalFilter = query.Count();
            }
            var data = new List<CauHoiDtoResult>();
            query.ForEach(d =>
            {
                var q = new CauHoiDtoResult()
                {
                    Id = d.Id,
                    TenCauHoi = d.TenCauHoi,
                    MonHoc = d.TN_MonHoc.TenMonHoc,
                    QuestionLevel = d.TN_QuestionLevel.Name,
                    TestType = d.TN_TestType.Name,
                    KichHoat = d.KichHoat ?? false,
                    GhiChu = d.GhiChu,
                };
                var answer = db.TN_CauHoi_DapAn.FirstOrDefault(v => v.CauHoi_Id == d.Id && v.IsDung);
                if (answer != null)
                {
                    q.DapAn = answer.TN_DapAn.DapAn + ". " + answer.GhiChu;
                }
                data.Add(q);
            });

            //ket qua tra ve
            var res = new DTResult<CauHoiDtoResult>()
            {
                recordsTotal = total,
                draw = draw,
                recordsFiltered = totalFilter,
                data = data.Skip(pageIndex).Take(pageSize).ToList()
            };
            return res;
        }

        
    }
}
