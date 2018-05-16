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
    [Route("api/Memories")]
    public class MemoriesController : Controller
    {
        private readonly speccomContext _context;

        public MemoriesController(speccomContext context)
        {
            _context = context;
        }

        // GET: api/Memories
        [HttpGet]
        public IEnumerable<Memory> GetMemory()
        {
            return _context.Memory;
        }

        // GET: api/Memories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var memory = await _context.Memory.SingleOrDefaultAsync(m => m.MemoryId == id);

            if (memory == null)
            {
                return NotFound();
            }

            return Ok(memory);
        }

        // PUT: api/Memories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemory([FromRoute] int id, [FromBody] Memory memory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != memory.MemoryId)
            {
                return BadRequest();
            }

            _context.Entry(memory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemoryExists(id))
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

        // POST: api/Memories
        [HttpPost]
        public async Task<IActionResult> PostMemory([FromBody] Memory memory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Memory.Add(memory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMemory", new { id = memory.MemoryId }, memory);
        }

        // DELETE: api/Memories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMemory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var memory = await _context.Memory.SingleOrDefaultAsync(m => m.MemoryId == id);
            if (memory == null)
            {
                return NotFound();
            }

            _context.Memory.Remove(memory);
            await _context.SaveChangesAsync();

            return Ok(memory);
        }

        private bool MemoryExists(int id)
        {
            return _context.Memory.Any(e => e.MemoryId == id);
        }
    }
}