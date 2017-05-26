using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lawfirm.Models.News
{
    public class DetailTinTucModel
    {
        public DetailTinTucModel()
        {
            TinTucCungLoai = new List<TintucModel>();
        }
        public TintucModel TinTuc { get; set; }
        public IList<TintucModel> TinTucCungLoai { get; set; } 
    }
}