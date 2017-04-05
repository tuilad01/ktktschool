using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dao.News
{
    public class NewResponse
    {
        public List<NewDetail> News { get; set; } 
    }

    public class NewDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Short { get; set; }
        public string Decription { get; set; }
        public byte[] ImgUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
