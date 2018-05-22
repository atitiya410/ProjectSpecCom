using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        public string AddComputer(Computer computer)
        {
            try
            {

       
            var computerid = _context.Computer.SingleOrDefault(a => a.ProcessorId == computer.ProcessorId);
            if (computerid == null)
            {
                _context.Computer.Add(computer);
                    ComputerUser computerUser = new ComputerUser();
                    computerUser.ProcessorId = computer.ProcessorId;
                    computerUser.UserId = computer.UserId;
                    _context.ComputerUser.Add(computerUser);
                    _context.SaveChanges();
            }
            else
            {
                 computerid.LastUpdate = computer.LastUpdate;
                _context.Entry(computerid).State = EntityState.Modified;
                _context.SaveChanges();
            }
            //------------------------------------Remove Memory  -----------------------//
            int m = 0;
            int memorycount = _context.Memory.Where(s => s.ProcessorId == computer.ProcessorId).Select(x => x.ProcessorId).Count();
            while (m < memorycount)
            {
                var memory = _context.Memory.Where(s => s.ProcessorId == computer.ProcessorId).FirstOrDefault();
                _context.Memory.Remove(memory);
                _context.SaveChanges();
                m++;
            }
            //----------------------------------End Remove Memory -----------------------//
            //-------------------------------------Remove DiskDrive-----------------------//
            int d = 0;
            int diskdrivecount = _context.DiskDrive.Where(s => s.ProcessorId == computer.ProcessorId).Select(x => x.ProcessorId).Count();
            while (d < diskdrivecount)
            {
                var diskdrive = _context.DiskDrive.Where(s => s.ProcessorId == computer.ProcessorId).FirstOrDefault();
                _context.DiskDrive.Remove(diskdrive);
                _context.SaveChangesAsync();
                d++;
            }
            //----------------------------------End Remove DiskDrive -----------------------//
            //----------------------------------Remove GraphicCard -----------------------//
            int g = 0;
            int GraphicCardcount = _context.GraphicCard.Where(s => s.ProcessorId == computer.ProcessorId).Select(x => x.ProcessorId).Count();
            while (g < GraphicCardcount)
            {
                var graphicCard = _context.GraphicCard.Where(s => s.ProcessorId == computer.ProcessorId).FirstOrDefault();
                _context.GraphicCard.Remove(graphicCard);
                _context.SaveChangesAsync();
                g++;
            }
            //---------------------------------End Remove GraphicCard -----------------------//
            foreach (var memory in computer.Memory)
            {
                memory.ProcessorId = computer.ProcessorId;
                _context.Memory.Add(memory);
                _context.SaveChanges();
            }
            foreach (var diskdrive in computer.DiskDrive)
            {
                diskdrive.ProcessorId = computer.ProcessorId;
                _context.DiskDrive.Add(diskdrive);
                _context.SaveChanges();
            }
            foreach (var graphiccard in computer.GraphicCard)
            {
                graphiccard.ProcessorId = computer.ProcessorId;
                _context.GraphicCard.Add(graphiccard);
                _context.SaveChanges();
            }
            

                return "Suscess";
            }
            catch (Exception ex)
            {
                return Convert.ToString(ex);
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
