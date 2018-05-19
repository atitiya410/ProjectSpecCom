using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SpeccomDB.Models;
using SpeccomInterface;

namespace WebapiSpeccom.Controllers
{
    [Produces("application/json")]
    [Route("api/Computers")]
    public class ComputersController : Controller
    {
        private readonly IComputer icomputer;

        public ComputersController(IComputer context)
        {
            icomputer = context;
        }

        // GET: api/Computers
        [HttpGet]
        public IEnumerable<Computer> GetComputer()
        {
            return icomputer.GetAllComputers();
        }

        // GET: api/Computers/5
        [HttpGet("{id}")]
        public IActionResult GetComputer([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var computerid = icomputer.GetComputerByID(id);
           

            if (computerid == null)
            {
                return NotFound();
            }

            return Ok(computerid);
        }

        // PUT: api/Computers/5
        [HttpPut("{id}")]
        public  IActionResult PutComputer([FromRoute] string id, [FromBody] Computer computer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != computer.ProcessorId)
            {
                return BadRequest();
            }

            icomputer.PutComputer(id,computer);

            return NoContent();
        }

        // POST: api/Computers
        [HttpPost]
        public IActionResult PostComputer([FromBody] Computer computer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            icomputer.AddComputer(computer);

            return CreatedAtAction("GetComputer", new { id = computer.ProcessorId }, computer);
        }

        // DELETE: api/Computers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteComputer([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var computer = await _context.Computer.SingleOrDefaultAsync(m => m.Cpuid == id);
        //    if (computer == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Computer.Remove(computer);
        //    await _context.SaveChangesAsync();

        //    return Ok(computer);
        //}

        //private bool ComputerExists(int id)
        //{
        //    return _context.Computer.Any(e => e.Cpuid == id);
        //}
    }
}