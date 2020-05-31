using RepairHouse.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepairHouse.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var currentUser =  HttpContext.Current.Session["CURRENT_SESSION"];

            if(currentUser == null)
            {
                if(filterContext.Controller is LoginController == false)
                {
                    if (filterContext.Controller is HomeController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Login/Index");
                    }
                }
            }
            else
            {
                if (filterContext.Controller is LoginController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }


            base.OnActionExecuting(filterContext);
        }
    }
}