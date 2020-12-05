using Alkemy_C.Filters;
using Alkemy_C.Handler;
using Alkemy_C.Models.EF_Models;
using Alkemy_C.Models.Materia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alkemy_C.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        [HttpGet]
        public ActionResult Materias()
        {
            return View("Materias",MateriaHandler.Materias()) ;
        }
        [HttpGet]
        [VerifyRole(role = "Admin")]
        public ActionResult EliminarHorario(int horarioId, int materiaId)
        {
            ViewBag.editarMateriaStatus = MateriaHandler.EliminarHorario(horarioId , materiaId);
            return EditarMateria(materiaId);
        }
        [HttpGet]
        public ActionResult MateriaDetails(int Id) {

            return View("MateriaDetails",MateriaHandler.getMateria(Id));
        }
        [HttpGet]
        [VerifyRole(role = "Admin")]
        public ActionResult AgregarMateria()
        {
            AgregarMateriaImportModel importModel = new AgregarMateriaImportModel();
            importModel.Teachers = ProfesorHandler.Profesores().Teachers;
            importModel.Schedules = MateriaHandler.getHorarios();
            return View("AgregarMateria",importModel);
        }
        [HttpGet]
        [VerifyRole(role = "Admin")]
        public ActionResult EliminarMateria(int id)
        {
            ViewBag.eliminarMateriaStatus = MateriaHandler.EliminarMateria(id).error;
            return Materias();
        }
        [HttpPost]
        [VerifyRole(role = "Admin")]
        public ActionResult AgregarMateria(AgregarMateriaImportModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.agregarMateriaStatus = MateriaHandler.AgregarMateria(model).error;
                
            }
            return AgregarMateria();
        }
        [HttpGet]
        [VerifyRole(role = "Admin")]
        public ActionResult EditarMateria(int Id)
        {
      
            return View("EditarMateria", MateriaHandler.EditarMateria(Id));
        }
        [HttpPost]
        [VerifyRole(role = "Admin")]
        public ActionResult EditarMateria(EditarMateriaImportModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.editarMateriaStatus = MateriaHandler.EditarMateria(model).error;

            }

            return EditarMateria(model.idMateria);
        }
        [HttpGet]
        [VerifyRole(role = "Alumn")]
        public ActionResult Inscribirse(int Id) {

            ViewBag.status = MateriaHandler.Inscribirse(Id).error;
            return MateriaDetails(Id);

        }
    }
}