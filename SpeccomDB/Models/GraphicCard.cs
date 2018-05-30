using System;
using System.Collections.Generic;

namespace SpeccomDB.Models
{
    public partial class GraphicCard
    {
        public int GraphicCardId { get; set; }
        public string Caption { get; set; }
        public int? AdapterRam { get; set; }
        public string Uuid { get; set; }

        public Computer Uu { get; set; }
    }
}
