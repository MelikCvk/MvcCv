using System.Web.Mvc;

namespace MvcCv
{
    public class SessionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session["KullaniciAdi"];
            var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            if (session == null && controller != "Login" && controller != "Default")
            {
                filterContext.Result = new RedirectResult("/Login/Index");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}