using Microsoft.EntityFrameworkCore;
using SpeccomDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace SpeccomInterface
{
    class MemoryService : IMemory
    {
        private readonly speccomContext _context;
        public MemoryService(speccomContext context)
        {
            _context = context;
        }
        public async void AddMemory(Memory memory)
        {
            var comid = _context.Computer.Max(s => s.ProcessorId);
            memory.ProcessorId = comid;


            _context.Memory.Add(memory);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Memory> GetAllMemories()
        {
            return _context.Memory;
        }

        public Memory GetMemoryByID(int id)
        {
            return _context.Memory.SingleOrDefault(m => m.MemoryId == id);
        }

        public void PutMemory(int id, Memory memory)
        {
            _context.Entry(memory).State = EntityState.Modified;
        }
    }
}
