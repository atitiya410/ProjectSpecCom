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
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly IUser userContext;

        public UsersController(IUser context)
        {
            userContext = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            return userContext.GetAllUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = userContext.GetUserByID(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult PutUser([FromRoute] int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }
            userContext.PutUser(id, user);



            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult PostUser([FromBody] User user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            userContext.AddUser(user);


            return Ok("Create New User");
        }

        //// DELETE: api/Users/5
        //[HttpDelete("{id}")]
        //public IActionResult DeleteUser([FromRoute] int id)
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return BadRequest(ModelState);
        //    //}

        //    //var user = _context.User.SingleOrDefaultAsync(m => m.UserId == id);
        //    //if (user == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //_context.User.Remove(user);
        //    //_context.SaveChangesAsync();

        //    //return Ok(user);
        //}

    }
}