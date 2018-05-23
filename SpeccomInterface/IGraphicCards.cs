using SpeccomDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeccomInterface
{
    public interface IGraphicCards
    {
        IEnumerable<GraphicCard> GetAllGraphicCard();
        User GetGraphicCardByID(int id);
        void PutGraphicCard(int id, GraphicCard graphicCard);
        void AddGraphicCard(GraphicCard graphicCard);
    }
}
