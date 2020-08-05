using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.CustomErrors
{
    public class CustomErrorHandlerAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            string cName = "Venky "+(string)filterContext.RouteData.Values["Controller"];
            string aName = (string)filterContext.RouteData.Values["Action"];
            HandleErrorInfo handleErrorInfo = new HandleErrorInfo(filterContext.Exception,cName,aName);

            ViewResult result = new ViewResult();
            result.ViewName = "CustomError";
            result.MasterName = this.Master;
            result.ViewData = new ViewDataDictionary<HandleErrorInfo>(handleErrorInfo);
            result.TempData = filterContext.Controller.TempData;
            filterContext.Result = result;

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

        }
    }
}