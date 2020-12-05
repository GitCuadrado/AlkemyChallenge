using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alkemy_C.Models.EF_Models
{
    public class Alumn : Person
    {
        public virtual ICollection<Subject> Subjects { get; set; }

    }
}