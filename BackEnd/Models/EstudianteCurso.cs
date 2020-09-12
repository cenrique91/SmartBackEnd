using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class EstudianteCurso
    {
        public int estudianteId { get; set; }
        public Estudiante Estudiante{ get; set; }

        public int cursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
