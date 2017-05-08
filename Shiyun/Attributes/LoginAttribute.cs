using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shiyun.Attributes
{
    public class LoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["Users_id"] == null)
            {
                //filterContext.HttpContext.Response.Redirect("/UserInfo/Login");
                //
                ContentResult cr = new ContentResult();
                cr.Content = "<script>alert('您尚未登陆，请登陆'); window.location='/UserInfo/Login' </script>";
                filterContext.Result = cr;
            }
        }
    }
}