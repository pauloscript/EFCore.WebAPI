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
    public class HeroisController : ControllerBase
    {
        private readonly heroContext _context;

        public HeroisController(heroContext context)
        {
            _context = context;
        }

        // GET: api/Herois
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Heroi>>> GetHerois()
        {
            return await _context.Herois.ToListAsync();
        }

        // GET: api/Herois/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Heroi>> GetHeroi(int id)
        {
            var heroi = await _context.Herois.FindAsync(id);

            if (heroi == null)
            {
                return NotFound();
            }

            return heroi;
        }

        // PUT: api/Herois/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeroi(int id, Heroi heroi)
        {
            if (id != heroi.Id)
            {
                return BadRequest();
            }

            _context.Entry(heroi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroiExists(id))
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

        // POST: api/Herois
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Heroi>> PostHeroi(Heroi heroi)
        {
            _context.Herois.Add(heroi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHeroi", new { id = heroi.Id }, heroi);
        }

        // DELETE: api/Herois/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeroi(int id)
        {
            var heroi = await _context.Herois.FindAsync(id);
            if (heroi == null)
            {
                return NotFound();
            }

            _context.Herois.Remove(heroi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeroiExists(int id)
        {
            return _context.Herois.Any(e => e.Id == id);
        }
    }
}
