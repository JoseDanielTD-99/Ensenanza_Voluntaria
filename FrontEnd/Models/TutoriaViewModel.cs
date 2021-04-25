using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class TutoriaViewModel
    {
        public int IdTutoriaCursos { get; set; }
        public string Descripcion { get; set; }
        public int? IdInstitucion { get; set; }
        public int? IdCurso { get; set; }
        public string FechaHora { get; set; }
    }
}
