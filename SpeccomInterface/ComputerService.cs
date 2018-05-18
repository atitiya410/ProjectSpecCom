using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebapiSpeccom.Models;

namespace SpeccomInterface
{
    public class ComputerService : IComputer
    {
        private readonly speccomContext _context;
        public ComputerService(speccomContext context)
        {
            _context = context;
        }

        public async void AddComputer(Computer computer)
        {
            var computerid = await _context.Computer.SingleOrDefaultAsync(a => a.Cpuid == computer.Cpuid);
            if (computerid == null)
            {
                _context.Computer.Add(computer);
                await _context.SaveChangesAsync();

            }
        }

        public IEnumerable<Computer> GetAllComputers()
        {
           return _context.Computer;
        }

        public Computer GetComputerByID(int id)
        {
            return _context.Computer.SingleOrDefault(m => m.Cpuid == id);
        }

        public void PutComputer(int id, Computer computer)
        {
            _context.Entry(computer).State = EntityState.Modified;

        }
    }
}
