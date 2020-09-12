using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ColegioDB;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstudianteCurso>().HasKey(sc => new { sc.estudianteId, sc.cursoId });
            modelBuilder.Entity<Curso>()
            .HasOne<Profesor>(c => c.Profesor)
            .WithMany(g => g.Cursos)
            .HasForeignKey(s => s.profesorId);
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<EstudianteCurso> EstudianteCursos { get; set; }
    }
}
