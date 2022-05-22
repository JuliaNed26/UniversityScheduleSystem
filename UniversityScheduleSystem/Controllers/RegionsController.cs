using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityScheduleSystem.Models;
using UniversityScheduleSystem.Models.Dto;

namespace UniversityScheduleSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly ScheduleSystemAPIContext _context;

        public RegionsController(ScheduleSystemAPIContext context)
        {
            _context = context;
        }

        // GET: api/Regions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionDto>>> GetRegions()
        {
          if (_context.Regions == null)
          {
              return NotFound();
          }

            var regions = from region in _context.Regions
                          select new RegionDto()
                          {
                              Id = region.Id,
                              Name = region.Name
                          };

            return await regions.ToListAsync();
        }

        // GET: api/Regions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegionDto>> GetRegion(int id)
        {
          if (_context.Regions == null)
          {
              return NotFound();
          }
            var region = await _context.Regions.FindAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var response = new RegionDto()
            {
                Id = region.Id,
                Name = region.Name
            };

            return response;
        }

        // PUT: api/Regions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegion(int id, Region region)
        {
            if (id != region.Id)
            {
                return BadRequest();
            }

            _context.Entry(region).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionExists(id))
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

        // POST: api/Regions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegionDto>> PostRegion(Region region)
        {
          if (_context.Regions == null)
          {
              return Problem("Entity set 'ScheduleSystemAPIContext.Regions'  is null.");
          }
            _context.Regions.Add(region);
            await _context.SaveChangesAsync();

            var response = new RegionDto()
            {
                Id = region.Id,
                Name = region.Name
            };

            return CreatedAtAction("GetRegion", new { id = response.Id }, response);
        }

        // DELETE: api/Regions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            if (_context.Regions == null)
            {
                return NotFound();
            }
            var region = await _context.Regions.FindAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegionExists(int id)
        {
            return (_context.Regions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
