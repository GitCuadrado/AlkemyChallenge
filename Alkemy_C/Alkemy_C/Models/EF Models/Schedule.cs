using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alkemy_C.Models.EF_Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string day { get; set; }
        public DateTime hr_start { get; set; }
        public DateTime hr_end { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}