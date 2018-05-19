using Microsoft.EntityFrameworkCore;
using SpeccomDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeccomInterface
{
    public class GraphicCardsService : IGraphicCards
    {
        private readonly speccomContext _context;
        public GraphicCardsService(speccomContext context)
        {
            _context = context;
        }

        public void AddGraphicCard(GraphicCard graphicCard)
        {
            
                _context.GraphicCard.Add(graphicCard);
                _context.SaveChangesAsync();

            
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
