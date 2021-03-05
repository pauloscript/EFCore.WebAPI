using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCore.Dominio;
using EFCore.Repo;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentidadeSecretasController : ControllerBase
    {
        private readonly heroContext _context;

        public IdentidadeSecretasController(heroContext context)
        {
            _context = context;
        }

        // GET: api/IdentidadeSecretas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentidadeSecreta>>> GetIdentidadeSecretas()
        {
            return await _context.IdentidadeSecretas.ToListAsync();
        }

        // GET: api/IdentidadeSecretas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdentidadeSecreta>> GetIdentidadeSecreta(int id)
        {
            var identidadeSecreta = await _context.IdentidadeSecretas.FindAsync(id);

            if (identidadeSecreta == null)
            {
                return NotFound();
            }

            return identidadeSecreta;
        }

        // PUT: api/IdentidadeSecretas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdentidadeSecreta(int id, IdentidadeSecreta identidadeSecreta)
        {
            if (id != identidadeSecreta.Id)
            {
                return BadRequest();
            }

            _context.Entry(identidadeSecreta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdentidadeSecretaExists(id))
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

        // POST: api/IdentidadeSecretas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IdentidadeSecreta>> PostIdentidadeSecreta(IdentidadeSecreta identidadeSecreta)
        {
            _context.IdentidadeSecretas.Add(identidadeSecreta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIdentidadeSecreta", new { id = identidadeSecreta.Id }, identidadeSecreta);
        }

        // DELETE: api/IdentidadeSecretas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdentidadeSecreta(int id)
        {
            var identidadeSecreta = await _context.IdentidadeSecretas.FindAsync(id);
            if (identidadeSecreta == null)
            {
                return NotFound();
            }

            _context.IdentidadeSecretas.Remove(identidadeSecreta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IdentidadeSecretaExists(int id)
        {
            return _context.IdentidadeSecretas.Any(e => e.Id == id);
        }
    }
}
