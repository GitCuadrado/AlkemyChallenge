using Alkemy_C.Controllers;
using Alkemy_C.Models.EF_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alkemy_C.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        private Person Person;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                Person = (Person)HttpContext.Current.Session["Usuario"];

                if (Person == null)
                {

                    if (filterContext.Controller is IngresoController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Ingreso/Ingreso");
                    }

                }
            }
            catch (Exception)
            {
                filterContext.HttpContext.Response.Redirect("~/Ingreso/Ingreso");
            }



        }
    }
}