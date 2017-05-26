using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.EF;
using Data.Model.Datatablejs;

namespace Data.Dao.News
{
    public class NewDao
    {
        private readonly lawfirmDbContext db = null;

        public NewDao()
        {
            db = new lawfirmDbContext();
        }

        public NewResponse GetAllNewsByTypeId(int typeid, int numberTake, int except = 0)
        {
            var qu
            var res = new NewResponse
            {
                News = db.TN_TinTuc.Where(d => d.TypeId == typeid && d.IsActive.Value).OrderByDescending(d => d.Id).Take(numberTake).ToList().Select(d => new NewDetail()
                {
                    Id = d.Id,
                    Decription = d.Description,
                    Short = d.Short,
                    ImgUrl = "data:image;base64," + Convert.ToBase64String(d.Image),
                    Title = d.Title,
                    CreatedAt = d.CreateAt ?? DateTime.Now
                }).ToList()
            };
            if (except > 0)
            {
                res.News = res.News.Where(d => d.Id != except).ToList();
            }

            return res;
        }

        public NewDetail GetNewsById(int id)
        {
            var news = db.TN_TinTuc.FirstOrDefault(d => d.Id == id);
            if (news == null) return null;
            var res = new NewDetail()
            {
                Id = news.Id,
                Decription = news.Description,
                ImgUrl = "data:image;base64," + Convert.ToBase64String(news.Image),
                Short = news.Short,
                Title = news.Title,
                CreatedAt = news.CreateAt ?? DateTime.Now,
                IsActive = news.IsActive ?? false,
                NewTypeId = news.TypeId ?? 0
            };
            return res;
        }

        public TN_TinTucLoai GeTinTucLoaiById(int id)
        {
            return db.TN_TinTucLoai.FirstOrDefault(d => d.Id == id);
        }

        public DTResult<NewDtoResult> SearchNews(int pageIndex, int pageSize, int draw, string title = "")
        {
            var query = db.TN_TinTuc.AsNoTracking().ToList();

            var total = query.Count();
            var totalFilter = total;


            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(d => d.Title.Contains(title)).ToList();
                totalFilter = query.Count();
            }

            var data = query.Select(d => new NewDtoResult()
            {
                Id = d.Id,
                Short = d.Short,
                Title = d.Title,
                IsActive = d.IsActive ?? false,
                Detail = d.Description,
                ImageId = d.Image,
                NewTypeId = d.TypeId ?? 0
            });

            return new DTResult<NewDtoResult>()
            {
                recordsTotal = total,
                draw = draw,
                recordsFiltered = totalFilter,
                data = data.Skip(pageIndex).Take(pageSize).ToList()
            };
        }

        public void InsertNew(TN_TinTuc tintuc)
        {
            db.TN_TinTuc.Add(tintuc);
            db.SaveChanges();
        }

        public void UpdateNew(TN_TinTuc tintuc)
        {
            db.Entry(tintuc).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<TN_TinTucLoai> GetAllLoaiTinTuc()
        {
            return db.TN_TinTucLoai.AsNoTracking().ToList();
        }

        public TN_TinTuc GetTinTucById(int id)
        {
            return db.TN_TinTuc.FirstOrDefault(d => d.Id == id);
        }

        public void DeleteNew(TN_TinTuc tintuc)
        {
            db.TN_TinTuc.Remove(tintuc);
            db.SaveChanges();
        }
    }
}
