using System;
using System.Collections.Generic;

namespace SpeccomDB.Models
{
    public partial class Computer
    {
        public Computer()
        {
            ComputerUser = new HashSet<ComputerUser>();
            DiskDrive = new HashSet<DiskDrive>();
            GraphicCard = new HashSet<GraphicCard>();
            Memory = new HashSet<Memory>();
            UserId = default(int?); 
        }

        public string ProcessorId { get; set; }
        public string Cpuname { get; set; }
        public int? Cores { get; set; }
        public int? Thread { get; set; }
        public DateTime LastUpdate { get; set; }
        public int? UserId { get; set; }

        public ICollection<ComputerUser> ComputerUser { get; set; }
        public ICollection<DiskDrive> DiskDrive { get; set; }
        public ICollection<GraphicCard> GraphicCard { get; set; }
        public ICollection<Memory> Memory { get; set; }
    }
}
