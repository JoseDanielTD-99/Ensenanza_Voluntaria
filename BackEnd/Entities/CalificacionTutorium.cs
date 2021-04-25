using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class CalificacionTutorium
    {
        public int IdCalificacionTutoria { get; set; }
        public decimal? Calificacion { get; set; }
        public int? IdTutoriaCursos { get; set; }

        public virtual TutoriaCurso IdTutoriaCursosNavigation { get; set; }
    }
}
