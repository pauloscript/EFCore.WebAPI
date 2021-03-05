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
    public class BatalhasController : ControllerBase
    {
        private readonly heroContext _context;

        public BatalhasController(heroContext context)
        {
            _context = context;
        }

        // GET: api/Batalhas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batalha>>> GetBatalhas()
        {
            return await _context.Batalhas.ToListAsync();
        }

        // GET: api/Batalhas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Batalha>> GetBatalha(int id)
        {
            var batalha = await _context.Batalhas.FindAsync(id);

            if (batalha == null)
            {
                return NotFound();
            }

            return batalha;
        }

        // PUT: api/Batalhas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBatalha(int id, Batalha batalha)
        {
            if (id != batalha.Id)
            {
                return BadRequest();
            }

            _context.Entry(batalha).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatalhaExists(id))
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

        // POST: api/Batalhas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Batalha>> PostBatalha(Batalha batalha)
        {
            _context.Batalhas.Add(batalha);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBatalha", new { id = batalha.Id }, batalha);
        }

        // DELETE: api/Batalhas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatalha(int id)
        {
            var batalha = await _context.Batalhas.FindAsync(id);
            if (batalha == null)
            {
                return NotFound();
            }

            _context.Batalhas.Remove(batalha);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BatalhaExists(int id)
        {
            return _context.Batalhas.Any(e => e.Id == id);
        }
    }
}
