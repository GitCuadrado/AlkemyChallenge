using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alkemy_C.Models.Ingreso
{
    public class IngresoImportModel
    {
        
        [Required(ErrorMessage = "campo obligatorio*")]
        [RegularExpression(@"^[0-9]*$",
         ErrorMessage = "Solo números*")]
        public int User { get; set; }
        [Required(ErrorMessage = "campo obligatorio*")]
        [RegularExpression(@"^[0-9]*$",
         ErrorMessage = "Solo números")]
        public int Pass { get; set; }
        public bool isAlumn { get; set; }
    }

}