using System;
using System.Collections.Generic;

namespace SpeccomDB.Models
{
    public partial class Memory
    {
        public int MemoryId { get; set; }
        public int Capacity { get; set; }
        public string MemoryType { get; set; }
        public string Uuid { get; set; }

        public Computer Uu { get; set; }
    }
}
