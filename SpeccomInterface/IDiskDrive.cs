using SpeccomDB.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace SpeccomInterface
{
    public interface IDiskDrive
    {
        IEnumerable<DiskDrive> GetAllDiskDrive();
        DiskDrive GetDiskDriveByID(int id);
        void PutDiskDrive(int id, DiskDrive diskDrive);
        void AddDiskDrive(DiskDrive diskDrive);

    }
}
