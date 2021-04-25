using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Institucion
    {
        public Institucion()
        {
            TutoriaCursos = new HashSet<TutoriaCurso>();
        }

        public int IdInstitucion { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TutoriaCurso> TutoriaCursos { get; set; }
    }
}
