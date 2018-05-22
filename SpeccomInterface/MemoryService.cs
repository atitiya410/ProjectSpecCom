using Microsoft.EntityFrameworkCore;
using SpeccomDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace SpeccomInterface
{
    public class MemoryService : IMemory
    {
        private readonly speccomContext _context;
        public MemoryService(speccomContext context)
        {
            _context = context;
        }
        public  void AddMemory(Memory memory)
        {
            
            _context.Memory.Add(memory);
             _context.SaveChangesAsync();
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
