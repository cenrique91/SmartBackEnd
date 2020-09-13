using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class EstudianteProfesor
    {
        public int estudianteId { get; set; }
        public Estudiante Estudiante { get; set; }
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }
    }
}

}
