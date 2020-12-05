using Alkemy_C.Models.EF_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alkemy_C.Models.Materia
{
    public class listaMaterias
    {
        public IEnumerable<Subject> Subjects { get; set; }
    }
}