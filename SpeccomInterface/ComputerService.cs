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

                string result = "";
                var computerid = _context.Computer.SingleOrDefault(a => a.ProcessorId == computer.ProcessorId);
                if (computerid == null)
                {
                    _context.Computer.Add(computer);
                    ComputerUser computerUser = new ComputerUser();
                    computerUser.ProcessorId = computer.ProcessorId;
                    computerUser.UserId = computer.UserId;
                    _context.ComputerUser.Add(computerUser);
                    _context.SaveChanges();
                    result = "Create New User";
                }
                else
                {
                    var comuser = _context.ComputerUser.SingleOrDefault(s => s.ProcessorId == computer.ProcessorId);
                    if (comuser != null)
                    {
                        computerid.LastUpdate = computer.LastUpdate;
                        _context.Entry(computerid).State = EntityState.Modified;
                        _context.SaveChanges();
                        var userid = _context.User.SingleOrDefault(a => a.UserId == computer.UserId);
                        if (userid.UserId != comuser.UserId)
                        {
                            _context.User.Remove(userid);
                            _context.SaveChanges();
                            var uid = _context.User.SingleOrDefault(a => a.UserId == comuser.UserId);
                            result = "Update User :" + uid.UserName;

                        }
                        else
                        {
                            result = "Update User :" + userid.UserName;
                        }

                    }

                }
                //------------------------------------Remove Memory  -----------------------//
                    var memoryall = _context.Memory.Where(s => s.ProcessorId == computer.ProcessorId);
                    _context.Memory.RemoveRange(memoryall);
                    _context.SaveChanges();
                //----------------------------------End Remove Memory -----------------------//
                //-------------------------------------Remove DiskDrive-----------------------//
                    var diskdriveall = _context.DiskDrive.Where(s => s.ProcessorId == computer.ProcessorId);
                    _context.DiskDrive.RemoveRange(diskdriveall);
                    _context.SaveChanges();              
                //----------------------------------End Remove DiskDrive -----------------------//
                //----------------------------------Remove GraphicCard -----------------------//

                var graphicCard = _context.GraphicCard.Where(s => s.ProcessorId == computer.ProcessorId);
                _context.GraphicCard.RemoveRange(graphicCard);
                _context.SaveChanges();
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


                return "Suscess " + result;
            }
            catch (Exception ex)
            {
                return Convert.ToString(ex);
            }

        }

        public IEnumerable<ComInfo> GetComputersInfo()
        {

            var items = (from c in _context.Computer
                         join cu in _context.ComputerUser on c.ProcessorId equals cu.ProcessorId
                         join us in _context.User on cu.UserId equals us.UserId
                         join m in _context.Memory on c.ProcessorId equals m.ProcessorId
                         select new ComInfo
                         {
                             UserId = us.UserId,
                             Cpuname = c.Cpuname,
                             Capacity = m.Capacity
                         });

            return items;
        }

        public Computer GetComputerByID(string id)
        {
            return _context.Computer.SingleOrDefault(m => m.ProcessorId == id);
        }

        public void PutComputer(string id, Computer computer)
        {
            _context.Entry(computer).State = EntityState.Modified;

        }

        public IEnumerable<Computer> GetAllComputers()
        {
            var items = _context.Computer
               .Include(c => c.DiskDrive)
               .Include(c => c.Memory)
               .Include(c => c.GraphicCard)
               .Include(u => u.ComputerUser).ThenInclude(uc => uc.User).ToList();
            return items;
        }
    }
}
