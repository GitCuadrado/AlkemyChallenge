using Alkemy_C.DataAccess;
using Alkemy_C.Models;
using Alkemy_C.Models.EF_Models;
using Alkemy_C.Models.Profesor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alkemy_C.Handler
{
    public static class ProfesorHandler
    {
        public static listaProfesores Profesores()
        {
            return ProfesorDataAccess.Profesores();
        }
        public static Teacher getProfesor(int Id)
        {
            return ProfesorDataAccess.getProfesor(Id);
        }

        public static ResponseGeneric ModificarProfesor(Teacher model)
        {
            ResponseGeneric response = new ResponseGeneric();
            response.status = false;
            if (ProfesorDataAccess.getPerson(model.Id) == null)
            {
                response = ProfesorDataAccess.ModificarProfesor(model);
                if (response.status)
                {
                    response.error = "Profesor modificado satisfactoriamente";
                }
                else
                {
                    response.error = "Error al modificar el profesor";
                }
            }
            else
            {
                response.error = "La persona ya existe en la base de datos";
            }


            return response;
        }
        public static ResponseGeneric EliminarProfesor(int Id)
        {
            ResponseGeneric response = ProfesorDataAccess.EliminarProfesor(Id);
            if (response.status)
            {
                response.error = "Profesor eliminado con exito";
            }
            else
            {
                response.error = "Hubo un error al eliminar el profesor";
            }
            return response;
        }
        public static ResponseGeneric CrearProfesor(CrearProfesorImportModel model)
        {
            ResponseGeneric response = new ResponseGeneric();
            if (ProfesorDataAccess.getPerson(model.ci) == null)
            {
                response = ProfesorDataAccess.CrearProfesor(model);
                if (response.status)
                {
                    response.error = "Profesor creado con exito";
                }
                else
                {
                    response.error = "Hubo un error al crear el profesor";
                }
            }
            else
            {
                response.error = "La persona ya existe en la base de datos";
            }
            return response;
        }
    }
}