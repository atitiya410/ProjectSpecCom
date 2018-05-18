using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WebapiSpeccom.Models;

namespace SpeccomInterface
{
    public interface IComputer
    {
        IEnumerable<Computer> GetAllComputers();
        Computer GetComputerByID(int id);
        void PutComputer(int id, Computer computer);
        void AddComputer(Computer computer);
    }
}
