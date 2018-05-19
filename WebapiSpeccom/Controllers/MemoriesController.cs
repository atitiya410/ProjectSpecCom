using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SpeccomDB.Models;
using SpeccomInterface;

namespace WebapiSpeccom.Controllers
{
    [Produces("application/json")]
    [Route("api/Memories")]
    public class MemoriesController : Controller
    {
        private readonly IMemory imemory;

        public MemoriesController(IMemory context)
        {
            imemory = context;
        }

        // GET: api/Memories
        [HttpGet]
        public IEnumerable<Memory> GetMemory()
        {
            return imemory.GetAllMemories();
        }

        // GET: api/Memories/5
        [HttpGet("{id}")]
        public IActionResult GetMemory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var memory = imemory.GetMemoryByID(id);

            if (memory == null)
            {
                return NotFound();
            }

            return Ok(memory);
        }

        // PUT: api/Memories/5
        [HttpPut("{id}")]
        public IActionResult PutMemory([FromRoute] int id, [FromBody] Memory memory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != memory.MemoryId)
            {
                return BadRequest();
            }

            imemory.PutMemory(id, memory);



            return NoContent();
        }

        // POST: api/Memories
        [HttpPost]
        public IActionResult PostMemory([FromBody] Memory memory)
        {
            imemory.AddMemory(memory);

            return CreatedAtAction("GetMemory", new { id = memory.MemoryId }, memory);
        }

        // DELETE: api/Memories/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMemory([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var memory = await _context.Memory.SingleOrDefaultAsync(m => m.MemoryId == id);
        //    if (memory == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Memory.Remove(memory);
        //    await _context.SaveChangesAsync();

        //    return Ok(memory);
        //}

        //private bool MemoryExists(int id)
        //{
        //    return _context.Memory.Any(e => e.MemoryId == id);
        //}
    }
}