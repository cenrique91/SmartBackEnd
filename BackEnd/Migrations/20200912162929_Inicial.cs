using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(nullable: true),
                    apellidos = table.Column<string>(nullable: true),
                    dni = table.Column<string>(nullable: true),
                    fechaNacimiento = table.Column<DateTime>(nullable: false),
                    direccion = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true),
                    correo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true),
                    profesorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cursos_Profesores_profesorId",
                        column: x => x.profesorId,
                        principalTable: "Profesores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true),
                    dni = table.Column<string>(nullable: true),
                    fechaNacimiento = table.Column<DateTime>(nullable: false),
                    direccion = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true),
                    correo = table.Column<string>(nullable: true),
                    ProfesorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Profesores_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstudianteCursos",
                columns: table => new
                {
                    estudianteId = table.Column<int>(nullable: false),
                    cursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudianteCursos", x => new { x.estudianteId, x.cursoId });
                    table.ForeignKey(
                        name: "FK_EstudianteCursos_Cursos_cursoId",
                        column: x => x.cursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstudianteCursos_Estudiantes_estudianteId",
                        column: x => x.estudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_profesorId",
                table: "Cursos",
                column: "profesorId");

            migrationBuilder.CreateIndex(
                name: "IX_EstudianteCursos_cursoId",
                table: "EstudianteCursos",
                column: "cursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_ProfesorId",
                table: "Estudiantes",
                column: "ProfesorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstudianteCursos");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Profesores");
        }
    }
}
