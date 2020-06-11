using RepairHouse.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepairHouse.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var currentUser =  HttpContext.Current.Session[Cons.USER_CURRENT_SESSION];

            if(currentUser == null)
            {
                if(filterContext.Controller is LoginController == false)
                {
                    if (filterContext.Controller is HomeController == false)
                    {
                        // aca manejamos para que el cliente pueda ingresar (cuando no hay sesion)
                        if (filterContext.Controller is ClientesController == true)
                        {
                            string routeName = (string)filterContext.RouteData.Values["action"];

                            Debug.WriteLine("routeName " + routeName);

                            if (!(routeName == "Crear" || routeName == "Registrarse")) // login no es necesario, el segundo if lo maneja
                            {
                                Debug.WriteLine("goTo Login/Index");

                                filterContext.HttpContext.Response.Redirect("~/Login/Index");
                            }
                        }
                        else
                        {
                            filterContext.HttpContext.Response.Redirect("~/Login/Index");
                        }
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