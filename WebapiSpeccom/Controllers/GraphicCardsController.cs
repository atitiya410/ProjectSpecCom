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
    [Route("api/GraphicCards")]
    public class GraphicCardsController : Controller
    {
        private readonly speccomContext _context;

        public GraphicCardsController(speccomContext context)
        {
            _context = context;
        }

        // GET: api/GraphicCards
        [HttpGet]
        public IEnumerable<GraphicCard> GetGraphicCard()
        {
            return _context.GraphicCard;
        }

        // GET: api/GraphicCards/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGraphicCard([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var graphicCard = await _context.GraphicCard.SingleOrDefaultAsync(m => m.GraphicCardId == id);

            if (graphicCard == null)
            {
                return NotFound();
            }

            return Ok(graphicCard);
        }

        // PUT: api/GraphicCards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGraphicCard([FromRoute] int id, [FromBody] GraphicCard graphicCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != graphicCard.GraphicCardId)
            {
                return BadRequest();
            }

            _context.Entry(graphicCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GraphicCardExists(id))
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

        // POST: api/GraphicCards
        [HttpPost]
        public async Task<IActionResult> PostGraphicCard([FromBody] GraphicCard graphicCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GraphicCard.Add(graphicCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGraphicCard", new { id = graphicCard.GraphicCardId }, graphicCard);
        }

        // DELETE: api/GraphicCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGraphicCard([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var graphicCard = await _context.GraphicCard.SingleOrDefaultAsync(m => m.GraphicCardId == id);
            if (graphicCard == null)
            {
                return NotFound();
            }

            _context.GraphicCard.Remove(graphicCard);
            await _context.SaveChangesAsync();

            return Ok(graphicCard);
        }

        private bool GraphicCardExists(int id)
        {
            return _context.GraphicCard.Any(e => e.GraphicCardId == id);
        }
    }
}