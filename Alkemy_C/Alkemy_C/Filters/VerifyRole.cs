using Alkemy_C.Models.EF_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alkemy_C.Filters
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple = false)]
    public class VerifyRole: AuthorizeAttribute 
    {
        public string role;
        public string url;
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (role == "Admin" && (Person)HttpContext.Current.Session["Usuario"] is Admin)
            {

            }
            else if (role == "Alumn" && (Person)HttpContext.Current.Session["Usuario"] is Alumn)
            {

            }
            else
            {
                filterContext.HttpContext.Response.Redirect("/Home/Index");

            }


        }
    }
}