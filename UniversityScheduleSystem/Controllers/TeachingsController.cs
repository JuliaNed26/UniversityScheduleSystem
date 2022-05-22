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
        public async Task<ActionResult<IEnumerable<Teaching>>> GetTeachings()
        {
          if (_context.Teachings == null)
          {
              return NotFound();
          }
            return await _context.Teachings.ToListAsync();
        }

        // GET: api/Teachings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teaching>> GetTeaching(int id)
        {
          if (_context.Teachings == null)
          {
              return NotFound();
          }
            var teaching = await _context.Teachings.FindAsync(id);

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
          if (_context.Teachings == null)
          {
              return Problem("Entity set 'ScheduleSystemAPIContext.Teachings'  is null.");
          }
            _context.Teachings.Add(teaching);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeaching", new { id = teaching.Id }, teaching);
        }

        // DELETE: api/Teachings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeaching(int id)
        {
            if (_context.Teachings == null)
            {
                return NotFound();
            }
            var teaching = await _context.Teachings.FindAsync(id);
            if (teaching == null)
            {
                return NotFound();
            }

            _context.Teachings.Remove(teaching);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeachingExists(int id)
        {
            return (_context.Teachings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
