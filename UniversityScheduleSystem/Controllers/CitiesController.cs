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
    public class CitiesController : ControllerBase
    {
        private readonly ScheduleSystemAPIContext _context;

        public CitiesController(ScheduleSystemAPIContext context)
        {
            _context = context;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCities()
        {
          if (_context.Cities == null)
          {
              return NotFound();
          }

            var cities = from city in _context.Cities
                         select new CityDto()
                         {
                             Id = city.Id,
                             Name = city.Name,
                             RegionId = city.RegionId
                         };

            return await cities.ToListAsync();
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetCity(int id)
        {
          if (_context.Cities == null)
          {
              return NotFound();
          }
            var city = await _context.Cities.FindAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            var response = new CityDto()
            {
                Id = city.Id,
                Name = city.Name,
                RegionId = city.RegionId
            };

            return response;
        }

        // PUT: api/Cities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, City city)
        {
            if (id != city.Id)
            {
                return BadRequest();
            }

            _context.Entry(city).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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

        // POST: api/Cities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
          if (_context.Cities == null)
          {
              return Problem("Entity set 'ScheduleSystemAPIContext.Cities'  is null.");
          }

            var newCity = new City()
            {
                Name = city.Name,
                RegionId = city.RegionId,
                Region = _context.Regions.Find(city.RegionId)
            };

            _context.Cities.Add(newCity);
            await _context.SaveChangesAsync();

            var response = new CityDto()
            {
                Id = newCity.Id,
                Name = newCity.Name,
                RegionId = newCity.RegionId
            };

            return CreatedAtAction("GetCity", new { id = response.Id }, response);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            if (_context.Cities == null)
            {
                return NotFound();
            }
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CityExists(int id)
        {
            return (_context.Cities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
