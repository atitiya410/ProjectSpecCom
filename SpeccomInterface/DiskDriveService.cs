using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebapiSpeccom.Models;

namespace SpeccomInterface
{
    public class DiskDriveService : IDiskDrive
    {
        private readonly speccomContext _context;
        public DiskDriveService(speccomContext context)
        {
            _context = context;
        }

        public async void AddDiskDrive(DiskDrive diskDrive)
        {
            var comid = _context.Computer.Max(s => s.Cpuid);
            diskDrive.Cpuid = comid;
           

            _context.DiskDrive.Add(diskDrive);
            await _context.SaveChangesAsync();
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
