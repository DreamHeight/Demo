using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowersDemo.Controllers
{
    public class AuthorizePowers : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if(httpContext.Request.Cookies["yourset"]==null&&httpContext.Session["CurrentUser"]==null){
                return false;
            }
            return base.AuthorizeCore(httpContext);
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if(filterContext.HttpContext.Response.StatusCode == 403){
                filterContext.Result = new RedirectResult("/Account/Login");
            }
        }
    }
}