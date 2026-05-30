using System.Web.Mvc;

namespace MvcCv
{
    public class SessionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            if (controller != "Login" && controller != "Default")
            {
                if (session["KullaniciAdi"] == null)
                {
                    filterContext.Result = new RedirectResult("/Login/Index");
                    return;
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}