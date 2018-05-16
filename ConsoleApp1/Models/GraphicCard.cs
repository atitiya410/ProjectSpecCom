using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public partial class GraphicCard
    {
        public int GraphicCardId { get; set; }
        public string Caption { get; set; }
        public int? AdapterRam { get; set; }
        public int Cpuid { get; set; }

        public Computer Cpu { get; set; }
    }
}
