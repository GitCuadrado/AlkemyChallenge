using Alkemy_C.Filters;
using Alkemy_C.Handler;
using Alkemy_C.Models;
using Alkemy_C.Models.EF_Models;
using Alkemy_C.Models.Profesor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alkemy_C.Controllers
{
    public class ProfesorController : Controller
    {
        // GET: Profesor
        [HttpGet]
        [VerifyRole(role = "Admin")]
        public ActionResult Profesores()
        {
            return View("Profesores",ProfesorHandler.Profesores());
        }
        [HttpGet]
        [VerifyRole(role = "Admin")]
        public ActionResult CrearProfesor()
        {
            return View();
        }
        [HttpPost]
        [VerifyRole(role = "Admin")]
        public ActionResult CrearProfesor(CrearProfesorImportModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.crearProfesorStatus = ProfesorHandler.CrearProfesor(model).error;

            }

            return View();
        }
        [HttpGet]
        [VerifyRole(role = "Admin")]
        public ActionResult ModificarProfesor(int Id)
        {
            return View(ProfesorHandler.getProfesor(Id));
        }
        [HttpPost]
        [VerifyRole(role = "Admin")]
        public ActionResult ModificarProfesor(Teacher model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.modificarProfesorStatus = ProfesorHandler.ModificarProfesor(model).error;
            }

            return View(ProfesorHandler.getProfesor(model.Id));
        }
        [HttpGet]
        [VerifyRole(role = "Admin")]
        public ActionResult EliminarProfesor(int Id)
        {
            ViewBag.eliminarProfesorStatus = ProfesorHandler.EliminarProfesor(Id).error;
            return Profesores();
        }
        [HttpGet]
        [VerifyRole(role = "Admin")]
        public ActionResult DetailsProfesor(int Id)
        {
            return View(ProfesorHandler.getProfesor(Id));
        }

    }
}