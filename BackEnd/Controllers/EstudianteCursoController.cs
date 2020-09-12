using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteCursoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EstudianteCursoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EstudianteCurso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstudianteCurso>>> GetEstudianteCursos()
        {
            return await _context.EstudianteCursos.ToListAsync();
        }

        // GET: api/EstudianteCurso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstudianteCurso>> GetEstudianteCurso(int id)
        {
            var estudianteCurso = await _context.EstudianteCursos.FindAsync(id);

            if (estudianteCurso == null)
            {
                return NotFound();
            }

            return estudianteCurso;
        }

        // PUT: api/EstudianteCurso/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudianteCurso(int id, EstudianteCurso estudianteCurso)
        {
            if (id != estudianteCurso.estudianteId)
            {
                return BadRequest();
            }

            _context.Entry(estudianteCurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteCursoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EstudianteCurso
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EstudianteCurso>> PostEstudianteCurso(EstudianteCurso estudianteCurso)
        {
            _context.EstudianteCursos.Add(estudianteCurso);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EstudianteCursoExists(estudianteCurso.estudianteId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEstudianteCurso", new { id = estudianteCurso.estudianteId }, estudianteCurso);
        }

        // DELETE: api/EstudianteCurso/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EstudianteCurso>> DeleteEstudianteCurso(int id)
        {
            var estudianteCurso = await _context.EstudianteCursos.FindAsync(id);
            if (estudianteCurso == null)
            {
                return NotFound();
            }

            _context.EstudianteCursos.Remove(estudianteCurso);
            await _context.SaveChangesAsync();

            return estudianteCurso;
        }

        private bool EstudianteCursoExists(int id)
        {
            return _context.EstudianteCursos.Any(e => e.estudianteId == id);
        }
    }
}
