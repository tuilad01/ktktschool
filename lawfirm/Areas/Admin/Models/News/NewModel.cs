using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lawfirm.Areas.Admin.Models.News
{
    public class NewModel
    {
        public NewModel()
        {
            NewType = new List<SelectListItem>();
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public HttpPostedFileBase Image { get; set; }

        public string Short { get; set; }

        public string Detail { get; set; }

        public bool IsActive { get; set; }

        public int NewTypeId { get; set; }

        public IList<SelectListItem>  NewType { get; set; }
    }
}