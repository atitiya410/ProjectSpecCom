using System;
using System.Collections.Generic;

namespace WebapiSpeccom.Models
{
    public partial class ComputerUser
    {
        public int UserId { get; set; }
        public int Cpuid { get; set; }

        public Computer Cpu { get; set; }
        public User User { get; set; }
    }
}
