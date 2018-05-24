using Microsoft.EntityFrameworkCore;
using SpeccomDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeccomInterface
{
    public class DiskDriveService : IDiskDrive
    {
        private readonly speccomContext _context;
        public DiskDriveService(speccomContext context)
        {
            _context = context;
        }

        public void AddDiskDrive(DiskDrive diskDrive)
        {

            _context.DiskDrive.Add(diskDrive);
            _context.SaveChangesAsync();
        }

        public IEnumerable<DiskDrive> GetAllDiskDrive()
        {
            return _context.DiskDrive;
        }

        public DiskDrive GetDiskDriveByID(int id)
        {
            return _context.DiskDrive.SingleOrDefault(m => m.DiskDriveId == id);
        }

        public void PutDiskDrive(int id, DiskDrive diskDrive)
        {
            _context.Entry(diskDrive).State = EntityState.Modified;
        }
    }
}
