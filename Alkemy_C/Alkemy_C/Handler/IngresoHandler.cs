using Alkemy_C.DataAccess;
using Alkemy_C.Models.EF_Models;
using Alkemy_C.Models.Ingreso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alkemy_C.Handler
{
    public static class IngresoHandler
    {
        public static Person Ingreso(IngresoImportModel model)
        {

            Person userReturn = IngresoDataAccess.Ingreso(model);
            bool retorno = false;

            if ( model.isAlumn && userReturn is Alumn)
            {
                retorno = true;
            }
            else if (!model.isAlumn && userReturn is Admin)
            {
                retorno = true;
            }
            if (retorno)
                return userReturn;
            else
                return null;
        }
    }
}