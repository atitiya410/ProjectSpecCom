﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpeccomDB.Models;
using SpeccomInterface;

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
        public ActionResult GetUser()
        {
            var item = userContext.GetAllUsers();
            return Ok(item);
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
            var jResult = JsonConvert.SerializeObject(user,
               Formatting.None,
               new JsonSerializerSettings()
               {
                   ReferenceLoopHandling = ReferenceLoopHandling.Ignore

               });
            if (user == null)
            {
                return NotFound();
            }

            return Ok(jResult);
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

            user =  userContext.AddUser(user);


            return Ok(user);
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