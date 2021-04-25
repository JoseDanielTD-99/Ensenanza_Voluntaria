using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class CalificacionTutoriaViewModel
    {

        public int IdCalificacionTutoria { get; set; }
        public decimal? Calificacion { get; set; }
        public int? IdTutoriaCursos { get; set; }

    }
}
