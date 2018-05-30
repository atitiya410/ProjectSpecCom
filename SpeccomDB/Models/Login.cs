using System;
using System.Collections.Generic;

namespace SpeccomDB.Models
{
    public partial class Login
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
