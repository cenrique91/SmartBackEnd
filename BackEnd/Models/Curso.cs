using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }
        public string nombre { get; set; }
        public int profesorId { get; set; }
        public Profesor Profesor { get; set; }
        public IList<EstudianteCurso> EstudianteCursos { get; set; }
    }
}
