using System;
using System.Collections.Generic;

namespace SpeccomDB.Models
{
    public partial class DiskDrive
    {
        public int DiskDriveId { get; set; }
        public int? Size { get; set; }
        public string Caption { get; set; }
        public int CPUID { get; set; }

        public Computer Processor { get; set; }
    }
}
