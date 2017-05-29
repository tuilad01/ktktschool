using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Data.EF;

namespace Data.Dao.Test
{
    public class TestDao
    {
        private readonly lawfirmDbContext db = null;

        public TestDao()
        {
            db = new lawfirmDbContext();
        }

        public List<TN_TestType> GetAllTestTypes()
        {
            return db.TN_TestType.ToList();
        }

        public string HandleName(string name)
        {
            var res  = ConvertToUnSign3(name);
            return res;
        }
        private static string ConvertToUnSign3(string s)
        {
            var regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            var temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, string.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').Replace(" ","-").ToLower();
        }

        public TN_TestType GeTestTypeById(int id)
        {
            return db.TN_TestType.Find(id);
        }

        public List<TN_QuestionLevel> GetAllQuestionLevels()
        {
            return db.TN_QuestionLevel.ToList();
        }

        public List<TN_CapHoc> GetAllCapHocs()
        {
            return db.TN_CapHoc.ToList();
        }

        public List<TN_KhoiLopHoc> GetAllKhoiLopHocs()
        {
            return db.TN_KhoiLopHoc.ToList();
        }

        public List<TN_Subject> GetAllSubjects()
        {
            return db.TN_Subject.ToList();
        }

        public List<TN_MonHoc> GetAllMonHocs()
        {
            return db.TN_MonHoc.ToList();
        }

        public TN_CapHoc GetCapHocByTestTypeId(int id)
        {
            return db.TN_CapHoc.FirstOrDefault(d => d.Id == id);
        }

        public List<TN_CauHoi_DapAn> GetTest(int monhocId, int questionLevel)
        {
            return db.TN_CauHoi_DapAn.Where(d => d.TN_CauHoi.TN_MonHoc.Id == monhocId).ToList();
        }

        public List<TN_TestType> GeTestTypesByType(int typeId)
        {
            return db.TN_TestType.Where(d => d.TypeId == typeId).ToList();
        }

        public List<TN_MonHoc> GetMonHocsByLopHoc(int lophocId)
        {
            return db.TN_MonHoc.Where(d => d.LopHoc_Id == lophocId && d.KichHoat.Value).ToList();
        }

        public void InsertCauHoiAndDapAn(List<TN_CauHoi_DapAn> cauHoiDap)
        {
            if (!cauHoiDap.Any()) throw  new ArgumentNullException(nameof(cauHoiDap));
            cauHoiDap.ForEach(d =>
            {
                db.TN_CauHoi_DapAn.Add(d);
            });
            db.SaveChanges();
        }

        public TN_CauHoi GetCauHoiById(int id)
        {
            return db.TN_CauHoi.FirstOrDefault(d => d.Id == id);
        }

        public List<TN_CauHoi_DapAn> GetDapAnsByCauhoiId(int cauhoiId)
        {
            return db.TN_CauHoi_DapAn.Where(d => d.CauHoi_Id == cauhoiId).ToList();
        }

        public TN_KhoiLopHoc GetLopHocByMonHoc(int monhocId)
        {
            var monhoc = db.TN_MonHoc.FirstOrDefault(d => d.Id == monhocId);
            return monhoc?.TN_KhoiLopHoc;
        }

        public void UpdateCauHoi(TN_CauHoi cauhoi)
        {
            db.TN_CauHoi.Attach(cauhoi);
            var entry = db.Entry(cauhoi);
            entry.State = EntityState.Modified;
            
            db.SaveChanges();
        }

        public void DeleteDapAn(List<TN_CauHoi_DapAn> cauHoiDapAns)
        {
            cauHoiDapAns.ForEach(d => db.TN_CauHoi_DapAn.Remove(d));
            db.SaveChanges();
        }

        public void DeleteCauHoi(TN_CauHoi cauhoi)
        {
            db.TN_CauHoi_DapAn.RemoveRange(cauhoi.TN_CauHoi_DapAn);
            db.TN_CauHoi.Remove(cauhoi);
            db.SaveChanges();
        }
        //Tao bai test theo yeu cau cua nguoi dung: random so cau hoi theo so luong yeu cau
        public TestResponse CreateTest(int quantityQuestion, int amoutTime = 0, int levelQuestion = 0, int monhoc = 0, int subject = 0,int userId = 0, string nameTest = "")
        {
            if (monhoc <= 0 && subject <= 0)
            {
                throw  new ArgumentNullException(nameof(monhoc));
            }

            var result = new TestResponse();
            
            //radom cau hoi
            var test =
                db.TN_CauHoi.Where(d => d.MonHoc_Id == monhoc && d.KichHoat.Value)
                    .OrderBy(d => Guid.NewGuid())
                    .Take(quantityQuestion).ToList();
            if (!test.Any()) return null;
            result.AmountTime = amoutTime;
         result.ListTest = new List<TestDetail>();
            //tao bai test luu vao db
            var now = DateTime.Now;
            var tnTest = new TN_Test()
            {
                CreateDate = now,
                QuestionLevelId = levelQuestion > 0 ? levelQuestion : (int?) null,
                EndDate = amoutTime > 0 ? now.AddMinutes(amoutTime) : (DateTime?) null,
                StatusTestId = (int) StatusTest.DangThucHien,
                TotalQuestion = quantityQuestion,
                UserId = userId > 0 ? userId : (int?) null,
                Description = nameTest
            };
            db.TN_Test.Add(tnTest);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                var error = ex;
                throw;
            }
        
            test.ForEach(d =>
            {
                var dapan = db.TN_CauHoi_DapAn.Where(v => v.CauHoi_Id == d.Id).ToList();
                var lcauhoi = new TestDetail()
                {
                    Id = d.Id,
                    Name = d.TenCauHoi,
                    ListAnwsers =  new List<Anwser>()
                };
                dapan.ForEach(v =>
                {
                    var da = new TN_TestDetails()
                    {
                        CauHoiId = d.Id,
                        DapAnId = v.DapAn_Id,
                        IsDung = v.IsDung,
                        TestId = tnTest.Id
                    };
                    db.TN_TestDetails.Add(da);
                    db.SaveChanges();
                    lcauhoi.ListAnwsers.Add(new Anwser()
                    {
                        Id = da.Id,
                        AnswerName = v.TN_DapAn.DapAn,
                        Description = v.GhiChu,
                    });
                });
                result.ListTest.Add(lcauhoi);
            });
         
            result.Id = tnTest.Id;
            
            return result;
        }

        public DoneTestResponse DoneTest(int testId, List<int> dapan)
        {
            if(testId <= 0) throw new ArgumentNullException(nameof(testId));
            var test = db.TN_TestDetails.Where(d => d.TestId == testId);
       
            var result = new DoneTestResponse()
            {
                Id = testId,
               
            };
            var t = db.TN_Test.FirstOrDefault(d => d.Id == testId);
            if (t != null)
            {
                result.NumberQuestion = t.TotalQuestion??0;
                result.StartAt = t.CreateDate?.ToString("dd/MM/yyyy HH:mm:ss");
                result.EndAt = t.EndDate?.ToString("dd/MM/yyyy HH:mm:ss");
            }
            var answer = test.Count(d => dapan.Any(v=>v == d.Id) && d.IsDung.Value);
            result.NumberRight = answer;
            
            var point = (float)(result.NumberRight*10)/result.NumberQuestion;
           
            var resultId = 0;
            if (point > 8.5)
            {
                resultId = (int)Result.XuatSac;
            }else if (point > 7)
            {
                resultId = (int)Result.Gioi;
            }else if (point > 5.5)
            {
                resultId = (int)Result.Kha;
            }
            else if (point > 4)
            {
                resultId = (int)Result.TrungBinh;
            }
            else if (point > 2.5)
            {
                resultId = (int)Result.Kem;
            }
            else
            {
                resultId = (int)Result.Yeu;
            }
            result.ResultPrecent = point*10;
            if (t != null)
            {
                t.StatusTestId = (int)StatusTest.HoanThanh;
                t.TotalRigth = result.NumberRight;
                t.ResultId = resultId;
                
            }
            db.SaveChanges();
            var rs = db.TN_Result.FirstOrDefault(d => d.Id == resultId);
            if (rs != null)
            {
                result.Result = rs.Name;
            }
            return result;
        }

        public IList<TestingResponse> GetTesting(int userId)
        {
            if(userId<=0) throw new ArgumentNullException(nameof(userId));
            return db.TN_Test
                .Where(d=>d.UserId == userId && d.StatusTestId == (int)StatusTest.DangThucHien)
                .Select(d=>new TestingResponse()
            {
                Id = d.Id,
                Name = d.Description
            }).ToList();

        }
    }
}
