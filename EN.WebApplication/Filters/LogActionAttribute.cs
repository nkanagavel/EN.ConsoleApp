using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EN.WebApplication.Utility;

namespace EN.WebApplication.Filters
{
    public class LogActionAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            var controller = filterContext.RouteData.Values["controller"].ToString();
            var action = filterContext.RouteData.Values["action"].ToString();
            var methodType = filterContext.HttpContext.Request.RequestType.ToString();
            ErrorLogger.WriteToFile($"OnActionExecuted - {action} action excuted on {controller} with {methodType} Method.", "Debug");

            base.OnActionExecuted(filterContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.RouteData.Values["controller"].ToString();
            var action = filterContext.RouteData.Values["action"].ToString();
            var methodType = filterContext.HttpContext.Request.RequestType.ToString();
            ErrorLogger.WriteToFile($"OnActionExecuting - {action} action excuted on {controller} with {methodType} Method.", "Debug");

            base.OnActionExecuting(filterContext);
        }
        //public override void OnResultExecuting(ResultExecutingContext filterContext)
        //{
        //    var controller = filterContext.RouteData.Values["controller"].ToString();
        //    var action = filterContext.RouteData.Values["action"].ToString();
        //    ErrorLogger.WriteToFile($"{action} action excuted on {controller}.", "Debug");

        //    base.OnResultExecuting(filterContext);
        //}
    }
}