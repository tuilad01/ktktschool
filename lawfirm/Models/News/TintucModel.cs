using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lawfirm.Models.News
{
    public class TintucModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Short { get; set; }
        public string Decription { get; set; }
        public string ImgUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}