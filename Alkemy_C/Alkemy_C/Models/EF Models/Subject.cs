using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alkemy_C.Models.EF_Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int places { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Alumn> Alumns { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}