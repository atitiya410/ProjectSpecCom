using System;
using System.Collections.Generic;
using System.Text;
using WebapiSpeccom.Models;

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
