using Microsoft.EntityFrameworkCore;
using SpeccomDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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
            var computerid = await _context.Computer.SingleOrDefaultAsync(a => a.ProcessorId == computer.ProcessorId);
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

        public Computer GetComputerByID(string id)
        {
            return _context.Computer.SingleOrDefault(m => m.ProcessorId == id);
        }

        public void PutComputer(string id, Computer computer)
        {
            _context.Entry(computer).State = EntityState.Modified;

        }
    }
}
