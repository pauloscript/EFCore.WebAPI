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
    public class HeroiBatalhasController : ControllerBase
    {
        private readonly heroContext _context;

        public HeroiBatalhasController(heroContext context)
        {
            _context = context;
        }

        // GET: api/HeroiBatalhas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeroiBatalha>>> GetHeroiBatalhas()
        {
            return await _context.HeroiBatalhas.ToListAsync();
        }

        // GET: api/HeroiBatalhas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HeroiBatalha>> GetHeroiBatalha(int id)
        {
            var heroiBatalha = await _context.HeroiBatalhas.FindAsync(id);

            if (heroiBatalha == null)
            {
                return NotFound();
            }

            return heroiBatalha;
        }

        // PUT: api/HeroiBatalhas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeroiBatalha(int id, HeroiBatalha heroiBatalha)
        {
            if (id != heroiBatalha.BatalhaId)
            {
                return BadRequest();
            }

            _context.Entry(heroiBatalha).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroiBatalhaExists(id))
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

        // POST: api/HeroiBatalhas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HeroiBatalha>> PostHeroiBatalha(HeroiBatalha heroiBatalha)
        {
            _context.HeroiBatalhas.Add(heroiBatalha);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HeroiBatalhaExists(heroiBatalha.BatalhaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHeroiBatalha", new { id = heroiBatalha.BatalhaId }, heroiBatalha);
        }

        // DELETE: api/HeroiBatalhas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeroiBatalha(int id)
        {
            var heroiBatalha = await _context.HeroiBatalhas.FindAsync(id);
            if (heroiBatalha == null)
            {
                return NotFound();
            }

            _context.HeroiBatalhas.Remove(heroiBatalha);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeroiBatalhaExists(int id)
        {
            return _context.HeroiBatalhas.Any(e => e.BatalhaId == id);
        }
    }
}
