using System.Web;
using System.Web.Mvc;
using Data.Dao.Users;
using lawfirm.Common;
using lawfirm.Models.Home;

namespace lawfirm.App_Start
{
    public class RedirectLoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // First check if authentication succeed and user authenticated:            
            var session = HttpContext.Current.Session[CommonConstants.USER_SESSION] as HomeUserModel;
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                    (new
                    {
                        area = "Admin",
                        controller = "Login",
                        action = "Index"
                    }));
            }
            else
            {
                var userDao = new UserDao();
                var user = userDao.GetUserByEmail(session.Email);
                if (user != null && user.TN_UserType.SystemName == UserType.Admin)
                {
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                        (new
                        {
                            area = "Admin",
                            controller = "Home",
                            action = "Index"
                        }));
             
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
             (new
             {
                 area = "Admin",
                 controller = "Login",
                 action = "Index"
             }));
                }

            }

            base.OnActionExecuted(filterContext);
        }
    }
}