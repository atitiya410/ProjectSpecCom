using System;
using System.Collections.Generic;

namespace SpeccomDB.Models
{
    public partial class DiskDrive
    {
        public int DiskDriveId { get; set; }
        public int? Size { get; set; }
        public string Caption { get; set; }
        public string Uuid { get; set; }

        public Computer Uu { get; set; }
    }
}
