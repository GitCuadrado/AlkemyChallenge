using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alkemy_C.Models.EF_Models
{
    public class Person
    {
        public int Id { get; set; }
        public int Ci { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
    }
}