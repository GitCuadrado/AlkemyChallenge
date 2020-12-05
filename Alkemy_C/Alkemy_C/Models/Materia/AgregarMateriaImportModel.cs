using Alkemy_C.Models.EF_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alkemy_C.Models.Materia
{
    public class AgregarMateriaImportModel
    {
        [Required(ErrorMessage = "campo obligatorio*")]
        [RegularExpression(@"^[a-z]*$", ErrorMessage = "solo caracteres*")]
        public string name { get; set; }
        [Required(ErrorMessage = "campo obligatorio*")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "solo números*")]
        public int places { get; set; }
        public int Teacher { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }
        [Required(ErrorMessage = "campo obligatorio*")]
        public List<int> SelectedSchedules { get; set; }

    }
}