using Alkemy_C.Handler;
using Alkemy_C.Models.Ingreso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alkemy_C.Controllers
{
    public class IngresoController : Controller
    {
        // GET: Ingreso
        [HttpGet]
        public ActionResult Ingreso()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ingreso(IngresoImportModel model) {

            if (ModelState.IsValid)
            {
                Session["Usuario"] = IngresoHandler.Ingreso(model);

                if (Session["Usuario"] != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.errorLogin = "Usuario o contraseña incorrectos";
                    return View();
                }
            }
            else
            {
                return View();
            }
        
           
        }
    }
}