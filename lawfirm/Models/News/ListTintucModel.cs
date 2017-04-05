using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lawfirm.Models.News
{
    public class ListTintucModel
    {
        public string NewsTypeName { get; set; }
        public List<TintucModel> ListTinTuc { get; set; } 
    }
}