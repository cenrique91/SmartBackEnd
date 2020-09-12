using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Profesor
    {
        [Key]
        public int Id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string dni { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public ICollection<Estudiante> Estudiantes { get; set; }
        public ICollection<Curso> Cursos { get; set; }
    }
}
