using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alkemy_C.Models.EF_Models
{
    public class Teacher : Person
    {
        public string active { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }

    }
}