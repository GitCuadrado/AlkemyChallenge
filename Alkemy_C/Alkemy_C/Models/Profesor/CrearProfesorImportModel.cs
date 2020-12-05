using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alkemy_C.Models.Profesor
{
    public class CrearProfesorImportModel
    {
        [Required(ErrorMessage = "campo obligatorio*")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "solo valores numericos*")]
        public int ci { get; set; }
        [Required(ErrorMessage = "campo obligatorio*")]
        [RegularExpression(@"^[a-z]*$", ErrorMessage = "solo caracteres*")]
        public string name { get; set; }
        [Required(ErrorMessage = "campo obligatorio*")]
        [RegularExpression(@"^[a-z]*$", ErrorMessage = "solo caracteres*")]
        public string last_name { get; set; }
    }
}