using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public partial class DiskDrive
    {
        public int DiskDriveId { get; set; }
        public int? Size { get; set; }
        public string Caption { get; set; }
        public int Cpuid { get; set; }

        public Computer Cpu { get; set; }
    }
}
