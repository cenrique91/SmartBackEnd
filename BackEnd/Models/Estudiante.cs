using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }
        public string nombre { get; set; }
        public string dni { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public IList<EstudianteCurso> EstudianteCursos { get; set; }

    }
}
