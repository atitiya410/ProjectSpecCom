using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public partial class Memory
    {
        public int MemoryId { get; set; }
        public int Capacity { get; set; }
        public string MemoryType { get; set; }
        public int Cpuid { get; set; }

        public Computer Cpu { get; set; }
    }
}
