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
    [Route("api/GraphicCards")]
    public class GraphicCardsController : Controller
    {
        private readonly IGraphicCards igraphicCards;

        public GraphicCardsController(IGraphicCards context)
        {
            igraphicCards = context;
        }

        // GET: api/GraphicCards
        [HttpGet]
        public IEnumerable<GraphicCard> GetGraphicCard()
        {
            return igraphicCards.GetAllGraphicCard();
        }

        // GET: api/GraphicCards/5
        [HttpGet("{id}")]
        public IActionResult GetGraphicCard([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var graphicCard = igraphicCards.GetGraphicCardByID(id);

            if (graphicCard == null)
            {
                return NotFound();
            }

            return Ok(graphicCard);
        }

        // PUT: api/GraphicCards/5
        [HttpPut("{id}")]
        public IActionResult PutGraphicCard([FromRoute] int id, [FromBody] GraphicCard graphicCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != graphicCard.GraphicCardId)
            {
                return BadRequest();
            }

            igraphicCards.PutGraphicCard(id, graphicCard);


            return NoContent();
        }

        // POST: api/GraphicCards
        [HttpPost]
        public IActionResult PostGraphicCard([FromBody] GraphicCard graphicCard)
        {
            igraphicCards.AddGraphicCard(graphicCard);

            return CreatedAtAction("GetGraphicCard", new { id = graphicCard.GraphicCardId }, graphicCard);
        }

        // DELETE: api/GraphicCards/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteGraphicCard([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var graphicCard = await _context.GraphicCard.SingleOrDefaultAsync(m => m.GraphicCardId == id);
        //    if (graphicCard == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.GraphicCard.Remove(graphicCard);
        //    await _context.SaveChangesAsync();

        //    return Ok(graphicCard);
        //}

        //private bool GraphicCardExists(int id)
        //{
        //    return _context.GraphicCard.Any(e => e.GraphicCardId == id);
        //}
    }
}