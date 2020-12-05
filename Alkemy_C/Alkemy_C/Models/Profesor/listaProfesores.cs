using Alkemy_C.Models.EF_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alkemy_C.Models.Profesor
{
    public class listaProfesores
    {
        public IEnumerable<Teacher> Teachers { get; set; }
    }
}