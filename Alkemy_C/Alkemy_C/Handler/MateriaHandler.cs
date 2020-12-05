using Alkemy_C.DataAccess;
using Alkemy_C.Models;
using Alkemy_C.Models.EF_Models;
using Alkemy_C.Models.Materia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alkemy_C.Handler
{
    public static class MateriaHandler
    {
        public static listaMaterias Materias() {

            listaMaterias listaretorno = new listaMaterias();
            listaretorno = MateriaDataAccess.Materias();

                if ((Person)HttpContext.Current.Session["Usuario"] is Alumn)
                {
                    Alumn alumno = MateriaDataAccess.getAlumno(((Person)HttpContext.Current.Session["Usuario"]).Id);
                    var filterList = listaretorno.Subjects.Where(x => !alumno.Subjects.Any(y => y.Id == x.Id));
                    listaretorno.Subjects = filterList.OrderBy(x => x.name);
                }
            return listaretorno;
        }

        public static Subject getMateria(int Id) {

            return MateriaDataAccess.getMateria(Id);
        }
        public static ResponseGeneric EliminarMateria(int Id) {
            ResponseGeneric response = new ResponseGeneric();
            if (MateriaDataAccess.EliminarMateria(Id))
            {
                response.error = "Materia eliminada con exito";
            }
            else
            {
                response.error = "Error al eliminar la materia";
            }
            return response;
        }
        public static ResponseGeneric EliminarHorario(int horarioId, int materiaId)
        {
            ResponseGeneric response = new ResponseGeneric();
            if (MateriaDataAccess.EliminarHorario(horarioId, materiaId))
            {
                response.error = "Horario eliminado con exito";
            }
            else
            {
                response.error = "Hubo un problema al eliminar el horario";
            }
            return response;
        }
        public static EditarMateriaImportModel EditarMateria(int Id) {

            EditarMateriaImportModel response = new EditarMateriaImportModel();
            Subject materia = MateriaHandler.getMateriaFULL(Id);
            response.Schedules = materia.Schedules;
            response.idMateria = Id;
            response.idTeacher = materia.Teachers.First().Id;
            response.Teachers = ProfesorHandler.Profesores().Teachers;
            response.name = materia.name;
            response.places = materia.places;
            return response;
        }
        public static ResponseGeneric EditarMateria(EditarMateriaImportModel model) {
            ResponseGeneric response = new ResponseGeneric();
            if (MateriaDataAccess.EditarMateria(model))
            {
                response.error = "Materia modificada exitosamente";
            }
            else
            {
                response.error = "Error al modificar la materia";

            }
            return response;
        }
        public static Subject getMateriaFULL(int Id) {

            return MateriaDataAccess.getMateriaFULL(Id);
        }
        public static ResponseGeneric AgregarMateria(AgregarMateriaImportModel model) {

            ResponseGeneric response = new ResponseGeneric();
            response.status = false;
            if (!MateriaDataAccess.ExistenciaMateria(model.name))
            {
                if (MateriaDataAccess.AgregarMateria(model))
                {
                    response.error = "Materia agregada con exito";
                }
                else
                {
                    response.error = "Error al agregar la materia";
                }
                
            }
            else
            {
                response.error = "Ya existe esta materia";
            }

            return response;
        }
        public static IEnumerable<Schedule> getHorarios() {
            return MateriaDataAccess.getHorarios();
        }
        public static ResponseGeneric Inscribirse(int Id) {
            ResponseGeneric response = new ResponseGeneric();
            response.status = false;

            Alumn alumno = MateriaDataAccess.getAlumno(((Alumn)HttpContext.Current.Session["Usuario"]).Id);
            Subject materia = MateriaDataAccess.getMateria(Id);

            if (alumno.Subjects != null)
            {
                if (!MateriaDataAccess.AlumnoInscrito(((Alumn)HttpContext.Current.Session["Usuario"]).Id, Id))
                {
                    foreach (var item in alumno.Subjects)
                    {
                        foreach (var subitem in item.Schedules)
                        {
                            foreach (var subsubitem in materia.Schedules)
                            {
                                if (subitem.Id == subsubitem.Id)
                                {
                                    response.status = true;
                                    response.error = "Horarios superpuestos";
                                }
                            }
                        }
                    }
                }
                else
                {
                    response.status = true;
                    response.error = "Ya estas inscrito en esta materia";
                }
            }
            if (!response.status)
            {
                if (materia.places > 0)
                {
                    MateriaDataAccess.Inscribirse(alumno.Id, materia.Id);
                    response.error = "Realizado";
                }
                else
                {
                    response.error = "No quedan cupos disponibles";
                }
            }

            return response;
        }
    }
}