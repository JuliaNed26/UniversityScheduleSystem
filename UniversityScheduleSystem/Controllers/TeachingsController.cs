#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityScheduleSystem.Models;

namespace UniversityScheduleSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachingsController : ControllerBase
    {
        private readonly ScheduleSystemAPIContext _context;

        public TeachingsController(ScheduleSystemAPIContext context)
        {
            _context = context;
        }

        // GET: api/Teachings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teaching>>> GetTeaching()
        {
            return await _context.Teaching.ToListAsync();
        }

        // GET: api/Teachings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teaching>> GetTeaching(int id)
        {
            var teaching = await _context.Teaching.FindAsync(id);

            if (teaching == null)
            {
                return NotFound();
            }

            return teaching;
        }

        // PUT: api/Teachings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeaching(int id, Teaching teaching)
        {
            if (id != teaching.Id)
            {
                return BadRequest();
            }

            _context.Entry(teaching).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeachingExists(id))
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

        // POST: api/Teachings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Teaching>> PostTeaching(Teaching teaching)
        {
            _context.Teaching.Add(teaching);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeaching", new { id = teaching.Id }, teaching);
        }

        // DELETE: api/Teachings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeaching(int id)
        {
            var teaching = await _context.Teaching.FindAsync(id);
            if (teaching == null)
            {
                return NotFound();
            }

            _context.Teaching.Remove(teaching);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeachingExists(int id)
        {
            return _context.Teaching.Any(e => e.Id == id);
        }
    }
}
