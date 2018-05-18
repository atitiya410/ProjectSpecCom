using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebapiSpeccom.Models;

namespace SpeccomInterface
{
    public class GraphicCardsService : IGraphicCards
    {
        private readonly speccomContext _context;
        public GraphicCardsService(speccomContext context)
        {
            _context = context;
        }

        public async void AddGraphicCard(GraphicCard graphicCard)
        {
            var graphic = await _context.GraphicCard.SingleOrDefaultAsync(a => a.Cpuid == graphicCard.Cpuid);
            if (graphic == null)
            {
                _context.GraphicCard.Add(graphic);
                await _context.SaveChangesAsync();

            }
        }

        public IEnumerable<GraphicCard> GetAllGraphicCard()
        {
            return _context.GraphicCard;
        }

        public GraphicCard GetGraphicCardByID(int id)
        {
            return _context.GraphicCard.SingleOrDefault(m => m.GraphicCardId == id);
        }

        public void PutGraphicCard(int id, GraphicCard graphicCard)
        {
            _context.Entry(graphicCard).State = EntityState.Modified;
        }

        User IGraphicCards.GetGraphicCardByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
