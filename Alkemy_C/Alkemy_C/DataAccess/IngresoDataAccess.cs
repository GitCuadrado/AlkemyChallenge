using Alkemy_C.Models.EF_Models;
using Alkemy_C.Models.Ingreso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alkemy_C.DataAccess
{
    public static class IngresoDataAccess
    {
        public static Person Ingreso(IngresoImportModel model)
        {
            Person solicitedPerson = new Person(); 
            {
                var db = new MyDbContext();
                solicitedPerson = db.Person.FirstOrDefault(x => x.Ci == model.User);
            }
            return solicitedPerson;
        }
    }
}