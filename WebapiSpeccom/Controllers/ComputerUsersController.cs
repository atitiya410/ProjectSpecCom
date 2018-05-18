using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeccomInterface;
using WebapiSpeccom.Models;

namespace WebapiSpeccom.Controllers
{
    [Produces("application/json")]
    [Route("api/ComputerUsers")]
    public class ComputerUsersController : Controller
    {
        private readonly IComputerUser icomputerUser;

        public ComputerUsersController(IComputerUser context)
        {
            icomputerUser = context;
        }

        // GET: api/ComputerUsers
        [HttpGet]
        public IEnumerable<ComputerUser> GetComputerUser()
        {
            return icomputerUser.GetComputerUser();
        }

        // GET: api/ComputerUsers/5
        [HttpGet("{id}")]
        public IActionResult GetComputerUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var computerUser = icomputerUser.GetCompuerUserByID(id);

            if (computerUser == null)
            {
                return NotFound();
            }

            return Ok(computerUser);
        }

        // PUT: api/ComputerUsers/5
        [HttpPut("{id}")]
        public IActionResult PutComputerUser([FromRoute] int id, [FromBody] ComputerUser computerUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != computerUser.UserId)
            {
                return BadRequest();
            }

            icomputerUser.PutComputerUser(id, computerUser);

            return NoContent();
        }

        // POST: api/ComputerUsers
        [HttpPost]
        public IActionResult PostComputerUser([FromBody] ComputerUser computerUser)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            icomputerUser.AddComputerUser(computerUser);

            return CreatedAtAction("GetComputerUser", new { id = computerUser.UserId }, computerUser);
        }

        // DELETE: api/ComputerUsers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteComputerUser([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var computerUser = await _context.ComputerUser.SingleOrDefaultAsync(m => m.UserId == id);
        //    if (computerUser == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.ComputerUser.Remove(computerUser);
        //    await _context.SaveChangesAsync();

        //    return Ok(computerUser);
        //}

        //private bool ComputerUserExists(int id)
        //{
        //    return _context.ComputerUser.Any(e => e.UserId == id);
        //}
    }
}