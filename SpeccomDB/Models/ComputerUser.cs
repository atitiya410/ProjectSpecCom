﻿using System;
using System.Collections.Generic;

namespace SpeccomDB.Models
{
    public partial class ComputerUser
    {
        public int? UserId { get; set; }
        public string Uuid { get; set; }

        public User User { get; set; }
        public Computer Uu { get; set; }
    }
}
