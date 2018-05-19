using Microsoft.EntityFrameworkCore;
using SpeccomDB.Models;
using System.Collections.Generic;
using System.Linq;

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
            var processorid = _context.Computer.Max(s => s.ProcessorId);
            var userid = _context.User.Max(m => m.UserId);
            var comuser = _context.ComputerUser.Where(s => s.ProcessorId == processorid && s.UserId == userid);
            if (comuser == null)
            {
                computerUser.UserId = userid;
                computerUser.ProcessorId = processorid;
                _context.ComputerUser.Add(computerUser);
            }
            


           
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
