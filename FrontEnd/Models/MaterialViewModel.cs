using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class MaterialViewModel
    {
        public int IdMaterialTutoria { get; set; }
        public int? IdTutoriaCursos { get; set; }
        public string DireccionArchivo { get; set; }

        [Display(Name = "Institución")]
        public InstitucionViewModel Institucion { get; set; }

        [Display(Name = "Curso")]
        public CursoViewModel Curso { get; set; }

        public TutoriaViewModel Tutoria { get; set; }
    }
}
