using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Curso
    {
        public Curso()
        {
            TutoriaCursos = new HashSet<TutoriaCurso>();
        }

        public int IdCurso { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TutoriaCurso> TutoriaCursos { get; set; }
    }
}
