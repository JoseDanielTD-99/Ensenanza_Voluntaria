using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class InstitucionViewModel
    {
        [Key]
        public int IdInstitucion { get; set; }

        [Display(Name = "Nombre de la institucion")]
        public string Nombre { get; set; }
    }
}
