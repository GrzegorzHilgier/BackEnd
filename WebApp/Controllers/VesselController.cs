using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VesselController : ControllerBase
    {
        private readonly VesselContext _context;

        public VesselController(VesselContext context)
        {
            _context = context;
        }

        // GET: api/Vessel
        [HttpGet]
        [Authorize]
        public IEnumerable<Vessel> GetVessel()
        {
            return _context.Vessel;
        }

        // GET: api/Vessel/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetVessel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vessel = await _context.Vessel.FindAsync(id);

            if (vessel == null)
            {
                return NotFound();
            }

            return Ok(vessel);
        }

        // PUT: api/Vessel/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutVessel([FromRoute] int id, [FromBody] Vessel vessel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vessel.Id)
            {
                return BadRequest();
            }

            _context.Entry(vessel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VesselExists(id))
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

        // POST: api/Vessel
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostVessel([FromBody] Vessel vessel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Vessel.Add(vessel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVessel", new { id = vessel.Id }, vessel);
        }

        // DELETE: api/Vessel/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteVessel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vessel = await _context.Vessel.FindAsync(id);
            if (vessel == null)
            {
                return NotFound();
            }

            _context.Vessel.Remove(vessel);
            await _context.SaveChangesAsync();

            return Ok(vessel);
        }

        private bool VesselExists(int id)
        {
            return _context.Vessel.Any(e => e.Id == id);
        }
    }
}