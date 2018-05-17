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
    [Route("api/ComputerUsers")]
    public class ComputerUsersController : Controller
    {
        private readonly speccomContext _context;

        public ComputerUsersController(speccomContext context)
        {
            _context = context;
        }

        // GET: api/ComputerUsers
        [HttpGet]
        public IEnumerable<ComputerUser> GetComputerUser()
        {
            return _context.ComputerUser;
        }

        // GET: api/ComputerUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComputerUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var computerUser = await _context.ComputerUser.SingleOrDefaultAsync(m => m.UserId == id);

            if (computerUser == null)
            {
                return NotFound();
            }

            return Ok(computerUser);
        }

        // PUT: api/ComputerUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComputerUser([FromRoute] int id, [FromBody] ComputerUser computerUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != computerUser.UserId)
            {
                return BadRequest();
            }

            _context.Entry(computerUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputerUserExists(id))
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

        // POST: api/ComputerUsers
        [HttpPost]
        public async Task<IActionResult> PostComputerUser([FromBody] ComputerUser computerUser)
        {
            var comid = _context.Computer.Max(s => s.Cpuid);
            var userid = _context.User.Max(m => m.UserId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            computerUser.UserId = userid;
            computerUser.Cpuid = comid;
            _context.ComputerUser.Add(computerUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ComputerUserExists(computerUser.UserId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetComputerUser", new { id = computerUser.UserId }, computerUser);
        }

        // DELETE: api/ComputerUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComputerUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var computerUser = await _context.ComputerUser.SingleOrDefaultAsync(m => m.UserId == id);
            if (computerUser == null)
            {
                return NotFound();
            }

            _context.ComputerUser.Remove(computerUser);
            await _context.SaveChangesAsync();

            return Ok(computerUser);
        }

        private bool ComputerUserExists(int id)
        {
            return _context.ComputerUser.Any(e => e.UserId == id);
        }
    }
}