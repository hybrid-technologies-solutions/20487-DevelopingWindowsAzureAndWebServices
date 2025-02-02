﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlueYonder.Core.Model;

namespace BlueYonder.Core.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly BlueYonderContext _context;

        public LocationsController(BlueYonderContext context)
        {
            _context = context;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locations>>> GetLocations()
        {
            return await _context.Locations.ToListAsync();
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Locations>> GetLocations(int id)
        {
            var locations = await _context.Locations.FindAsync(id);

            if (locations == null)
            {
                return NotFound();
            }

            return locations;
        }

        // PUT: api/Locations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocations(int id, Locations locations)
        {
            if (id != locations.LocationId)
            {
                return BadRequest();
            }

            _context.Entry(locations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationsExists(id))
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

        // POST: api/Locations
        [HttpPost]
        public async Task<ActionResult<Locations>> PostLocations(Locations locations)
        {
            _context.Locations.Add(locations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocations", new { id = locations.LocationId }, locations);
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Locations>> DeleteLocations(int id)
        {
            var locations = await _context.Locations.FindAsync(id);
            if (locations == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(locations);
            await _context.SaveChangesAsync();

            return locations;
        }

        private bool LocationsExists(int id)
        {
            return _context.Locations.Any(e => e.LocationId == id);
        }
    }
}
