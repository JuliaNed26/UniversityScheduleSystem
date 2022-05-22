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
    public class TeacherUniversitiesController : ControllerBase
    {
        private readonly ScheduleSystemAPIContext _context;

        public TeacherUniversitiesController(ScheduleSystemAPIContext context)
        {
            _context = context;
        }

        // GET: api/TeacherUniversities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherUniversity>>> GetTeacherUniversities()
        {
          if (_context.TeacherUniversities == null)
          {
              return NotFound();
          }
            return await _context.TeacherUniversities.ToListAsync();
        }

        // GET: api/TeacherUniversities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherUniversity>> GetTeacherUniversity(int id)
        {
          if (_context.TeacherUniversities == null)
          {
              return NotFound();
          }
            var teacherUniversity = await _context.TeacherUniversities.FindAsync(id);

            if (teacherUniversity == null)
            {
                return NotFound();
            }

            return teacherUniversity;
        }

        // PUT: api/TeacherUniversities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacherUniversity(int id, TeacherUniversity teacherUniversity)
        {
            if (id != teacherUniversity.Id)
            {
                return BadRequest();
            }

            _context.Entry(teacherUniversity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherUniversityExists(id))
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

        // POST: api/TeacherUniversities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeacherUniversity>> PostTeacherUniversity(TeacherUniversity teacherUniversity)
        {
          if (_context.TeacherUniversities == null)
          {
              return Problem("Entity set 'ScheduleSystemAPIContext.TeacherUniversities'  is null.");
          }
            _context.TeacherUniversities.Add(teacherUniversity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacherUniversity", new { id = teacherUniversity.Id }, teacherUniversity);
        }

        // DELETE: api/TeacherUniversities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacherUniversity(int id)
        {
            if (_context.TeacherUniversities == null)
            {
                return NotFound();
            }
            var teacherUniversity = await _context.TeacherUniversities.FindAsync(id);
            if (teacherUniversity == null)
            {
                return NotFound();
            }

            _context.TeacherUniversities.Remove(teacherUniversity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeacherUniversityExists(int id)
        {
            return (_context.TeacherUniversities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
