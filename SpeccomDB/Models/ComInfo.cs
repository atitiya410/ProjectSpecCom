using System;
using System.Collections.Generic;
using System.Text;

namespace SpeccomDB.Models
{
    public class ComInfo
    {
        public string UserName { get; set; }
        public string CPU { get; set; }
        public int Ram { get; set; }
        public int? HardDiskDrive { get; set; }
        public DateTime LastUpdate { get; set; }

    }
}
