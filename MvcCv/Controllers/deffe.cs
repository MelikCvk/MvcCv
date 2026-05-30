using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class deffe : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["KullaniciAdi"] == null)
            {
                filterContext.Result = RedirectToAction("Index", "Login");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}