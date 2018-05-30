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
                var computerid = _context.Computer.SingleOrDefault(a => a.Uuid == computer.Uuid);
                if (computerid == null)
                {
                    _context.Computer.Add(computer);
                    ComputerUser computerUser = new ComputerUser();
                    computerUser.Uuid = computer.Uuid;
                    computerUser.UserId = computer.UserId;
                    _context.ComputerUser.Add(computerUser);
                    _context.SaveChanges();
                    result = "Create New User";
                }
                else
                {
                    //------------------------------------Remove Memory  -----------------------//
                    var memoryall = _context.Memory.Where(s => s.Uuid == computer.Uuid);
                    _context.Memory.RemoveRange(memoryall);
                    _context.SaveChanges();
                    //----------------------------------End Remove Memory -----------------------//
                    //-------------------------------------Remove DiskDrive-----------------------//
                    var diskdriveall = _context.DiskDrive.Where(s => s.Uuid == computer.Uuid);
                    _context.DiskDrive.RemoveRange(diskdriveall);
                    _context.SaveChanges();
                    //----------------------------------End Remove DiskDrive -----------------------//
                    //----------------------------------Remove GraphicCard -----------------------//

                    var graphicCard = _context.GraphicCard.Where(s => s.Uuid == computer.Uuid);
                    _context.GraphicCard.RemoveRange(graphicCard);
                    _context.SaveChanges();
                    //---------------------------------End Remove GraphicCard -----------------------//
                    foreach (var memory in computer.Memory)
                    {
                        memory.Uuid = computer.Uuid;
                        _context.Memory.Add(memory);
                        _context.SaveChanges();
                    }
                    foreach (var diskdrive in computer.DiskDrive)
                    {
                        diskdrive.Uuid = computer.Uuid;
                        _context.DiskDrive.Add(diskdrive);
                        _context.SaveChanges();
                    }
                    foreach (var graphiccard in computer.GraphicCard)
                    {
                        graphiccard.Uuid = computer.Uuid;
                        _context.GraphicCard.Add(graphiccard);
                        _context.SaveChanges();
                    }
                    var comuser = _context.ComputerUser.SingleOrDefault(s => s.Uuid == computer.Uuid);
                    if (comuser != null)
                    {
                        computerid.LastUpdate = computer.LastUpdate;
                        _context.Entry(computerid).State = EntityState.Modified;
                        _context.SaveChanges();
                        var userid = _context.User.SingleOrDefault(a => a.UserId == computer.UserId);
                        if (userid.UserId != comuser.UserId)
                        {   
                            var user = _context.User.SingleOrDefault(a => a.UserId == comuser.UserId);
                            user.UserName = userid.UserName;
                            _context.Entry(user).State = EntityState.Modified;
                            var unew = _context.ComputerUser.SingleOrDefault(s => s.UserId == userid.UserId);
                            if (unew == null)
                            {
                                _context.User.Remove(userid);
                                _context.SaveChanges();
                            }
                           
                            result = "Update User :" + user.UserName;

                        }
                        else
                        {
                            result = "Update User :" + userid.UserName;
                        }

                    }

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
                         join cu in _context.ComputerUser on c.Uuid equals cu.Uuid
                         join us in _context.User on cu.UserId equals us.UserId
                         join m in _context.Memory on c.Uuid equals m.Uuid
                         join hdd in _context.DiskDrive on c.Uuid equals hdd.Uuid
                         select new ComInfo
                         {
                             UserName = us.UserName,
                             CPU = c.Cpuname,
                             Ram = c.Memory.Sum(s => s.Capacity),
                             HardDiskDrive = hdd.Size,
                             LastUpdate = c.LastUpdate
                         });

            List<ComInfo> coms = new List<ComInfo>();

            foreach (var item in items)
            {
                if (!isExist(coms, item.UserName))
                {
                    coms.Add(item);
                }
            }

            return coms;
        }

        private bool isExist(List<ComInfo> coms, string UserName)
        {
            foreach (var item in coms)
            {
                if (item.UserName == UserName)
                {
                    return true;
                }
                    
            }

            return false;
        }

        public Computer GetComputerByID(string id)
        {
            return _context.Computer.SingleOrDefault(m => m.Uuid == id);
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
               .Include(c => c.GraphicCard).ToList();
            return items;
        }
    }
}
