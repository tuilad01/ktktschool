using System.Web.Mvc;

namespace lawfirm.Controllers
{
    public class HomePageController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Page");
        }

        public ActionResult Page()
        {
            return View();
        }
    }
}