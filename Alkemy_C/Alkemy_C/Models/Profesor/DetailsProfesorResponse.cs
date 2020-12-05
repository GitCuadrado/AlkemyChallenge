using Alkemy_C.Models.EF_Models;
using Alkemy_C.Models.Materia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alkemy_C.Models.Profesor
{
    public class DetailsProfesorResponse
    {
        public Teacher Teacher { get; set; }
        public IEnumerable<Subject> materiasDisp { get; set; }
    }
}