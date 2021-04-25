using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class MaterialTutorium
    {
        public int IdMaterialTutoria { get; set; }
        public int? IdTutoriaCursos { get; set; }
        public string DireccionArchivo { get; set; }

        public virtual TutoriaCurso IdTutoriaCursosNavigation { get; set; }
    }
}
