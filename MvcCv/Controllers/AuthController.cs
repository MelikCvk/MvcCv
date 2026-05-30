using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AuthController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["KullaniciAdi"] == null)
            {
                filterContext.Result = new RedirectResult("/Login/Index");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}