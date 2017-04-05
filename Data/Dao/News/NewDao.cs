using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.EF;

namespace Data.Dao.News
{
    public class NewDao
    {
        private readonly lawfirmDbContext db = null;

        public NewDao()
        {
            db = new lawfirmDbContext();
        }

        public NewResponse GetAllNewsByTypeId(int typeid, int numberTake)
        {
            
            var res = new NewResponse
            {
                News = db.TN_TinTuc.Where(d => d.TypeId == typeid && d.IsActive.Value).OrderByDescending(d=>d.Id).Take(numberTake).Select(d => new NewDetail()
                {
                    Id = d.Id,
                    Decription = d.Description,
                    Short = d.Short,
                    ImgUrl = d.Image,
                    Title = d.Title,
                    CreatedAt = d.CreateAt?? DateTime.Now
                }).ToList()
            };
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
                ImgUrl = news.Image,
                Short = news.Short,
                Title = news.Title,
                CreatedAt = news.CreateAt?? DateTime.Now
            };
            return res;
        }

        public TN_TinTucLoai GeTinTucLoaiById(int id)
        {
            return db.TN_TinTucLoai.FirstOrDefault(d=>d.Id == id);
        }
    }
}
