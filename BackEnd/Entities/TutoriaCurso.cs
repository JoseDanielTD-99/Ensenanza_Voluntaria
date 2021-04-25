using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class TutoriaCurso
    {
        public TutoriaCurso()
        {
            CalificacionTutoria = new HashSet<CalificacionTutorium>();
            MaterialTutoria = new HashSet<MaterialTutorium>();
        }

        public int IdTutoriaCursos { get; set; }
        public string Descripcion { get; set; }
        public int? IdInstitucion { get; set; }
        public int? IdCurso { get; set; }
        public string FechaHora { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Institucion IdInstitucionNavigation { get; set; }
        public virtual ICollection<CalificacionTutorium> CalificacionTutoria { get; set; }
        public virtual ICollection<MaterialTutorium> MaterialTutoria { get; set; }
    }
}
