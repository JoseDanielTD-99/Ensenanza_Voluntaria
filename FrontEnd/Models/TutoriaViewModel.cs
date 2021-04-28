using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class TutoriaViewModel
    {
        public int IdTutoriaCursos { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Institución")]
        public int IdInstitucion { get; set; }
        public IEnumerable<InstitucionViewModel> Institucions { get; set; }

        [Display(Name = "Institución")]
        public InstitucionViewModel Institucion { get; set; }

        [Display(Name = "Curso")]
        public int IdCurso { get; set; }
        public IEnumerable<CursoViewModel> Cursos { get; set; }

        [Display(Name = "Curso")]
        public CursoViewModel Curso { get; set; }

        [Display(Name = "Fecha y Hora")]
        public string FechaHora { get; set; }

        [Display(Name = "Promedio de calificaciones")]
        public decimal? calificaciones { get; set; }
    }
}
