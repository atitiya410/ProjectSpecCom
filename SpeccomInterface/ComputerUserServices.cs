using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebapiSpeccom.Models;

namespace SpeccomInterface
{
    public class ComputerUserServices : IComputerUser
    {
        private readonly speccomContext _context;
        public ComputerUserServices(speccomContext context)
        {
            _context = context;
        }

        public void AddComputerUser(ComputerUser computerUser)
        {
            var comid = _context.Computer.Max(s => s.Cpuid);
            var userid = _context.User.Max(m => m.UserId);
           

            computerUser.UserId = userid;
            computerUser.Cpuid = comid;
            _context.ComputerUser.Add(computerUser);
        }

        public ComputerUser GetCompuerUserByID(int id)
        {
            return  _context.ComputerUser.SingleOrDefault(m => m.UserId == id);

        }

        public IEnumerable<ComputerUser> GetComputerUser()
        {
            return _context.ComputerUser;
        }

        public void PutComputerUser(int id, ComputerUser computerUser)
        {
            _context.Entry(computerUser).State = EntityState.Modified;
        }
    }
}
