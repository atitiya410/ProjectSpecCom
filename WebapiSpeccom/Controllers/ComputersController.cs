using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebapiSpeccom.Models;

namespace WebapiSpeccom.Controllers
{
    [Produces("application/json")]
    [Route("api/Computers")]
    public class ComputersController : Controller
    {
        private readonly speccomContext _context;

        public ComputersController(speccomContext context)
        {
            _context = context;
        }

        // GET: api/Computers
        [HttpGet]
        public IEnumerable<Computer> GetComputer()
        {
            return _context.Computer;
        }

        // GET: api/Computers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComputer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var computer = await _context.Computer.SingleOrDefaultAsync(m => m.Cpuid == id);
            var comid = _context.Computer.Max(s => s.Cpuid);

            if (computer == null)
            {
                return NotFound();
            }

            return Ok(comid);
        }

        // PUT: api/Computers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComputer([FromRoute] int id, [FromBody] Computer computer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != computer.Cpuid)
            {
                return BadRequest();
            }

            _context.Entry(computer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputerExists(id))
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

        // POST: api/Computers
        [HttpPost]
        public async Task<IActionResult> PostComputer([FromBody] Computer computer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var processorId = await _context.Computer.SingleOrDefaultAsync(m => m.ProcessorId == computer.ProcessorId);

            _context.Computer.Add(computer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComputer", new { id = computer.Cpuid }, computer);
        }

        // DELETE: api/Computers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComputer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var computer = await _context.Computer.SingleOrDefaultAsync(m => m.Cpuid == id);
            if (computer == null)
            {
                return NotFound();
            }

            _context.Computer.Remove(computer);
            await _context.SaveChangesAsync();

            return Ok(computer);
        }

        private bool ComputerExists(int id)
        {
            return _context.Computer.Any(e => e.Cpuid == id);
        }
    }
}