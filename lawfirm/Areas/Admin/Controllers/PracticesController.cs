using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lawfirm.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PracticesController : Controller
    {
        // GET: Admin/Practices
       
        public ActionResult Index()
        {
            return View();
        }
    }
}