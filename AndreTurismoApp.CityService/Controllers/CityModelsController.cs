using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.CityService.Data;
using Models;

namespace AndreTurismoApp.CityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityModelsController : ControllerBase
    {
        private readonly AndreTurismoAppCityServiceContext _context;

        public CityModelsController(AndreTurismoAppCityServiceContext context)
        {
            _context = context;
        }

        // GET: api/CityModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityModel>>> GetCityModel()
        {
          if (_context.CityModel == null)
          {
              return NotFound();
          }
            return await _context.CityModel.ToListAsync();
        }

        // GET: api/CityModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityModel>> GetCityModel(int id)
        {
          if (_context.CityModel == null)
          {
              return NotFound();
          }
            var cityModel = await _context.CityModel.FindAsync(id);

            if (cityModel == null)
            {
                return NotFound();
            }

            return cityModel;
        }

        // PUT: api/CityModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCityModel(int id, CityModel cityModel)
        {
            if (id != cityModel.Id_City)
            {
                return BadRequest();
            }

            _context.Entry(cityModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityModelExists(id))
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

        // POST: api/CityModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CityModel>> PostCityModel(CityModel cityModel)
        {
          if (_context.CityModel == null)
          {
              return Problem("Entity set 'AndreTurismoAppCityServiceContext.CityModel'  is null.");
          }
            _context.CityModel.Add(cityModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCityModel", new { id = cityModel.Id_City }, cityModel);
        }

        // DELETE: api/CityModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCityModel(int id)
        {
            if (_context.CityModel == null)
            {
                return NotFound();
            }
            var cityModel = await _context.CityModel.FindAsync(id);
            if (cityModel == null)
            {
                return NotFound();
            }

            _context.CityModel.Remove(cityModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CityModelExists(int id)
        {
            return (_context.CityModel?.Any(e => e.Id_City == id)).GetValueOrDefault();
        }
    }
}
