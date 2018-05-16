using System;
using System.Collections.Generic;

namespace WebapiSpeccom.Models
{
    public partial class User
    {
        public User()
        {
            ComputerUser = new HashSet<ComputerUser>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public ICollection<ComputerUser> ComputerUser { get; set; }
    }
}
