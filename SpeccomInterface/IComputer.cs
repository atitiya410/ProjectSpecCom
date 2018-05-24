using SpeccomDB.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace SpeccomInterface
{
    public interface IComputer
    {
        IEnumerable<Computer> GetAllComputers();
        Computer GetComputerByID(string id);
        void PutComputer(string id, Computer computer);
        string AddComputer(Computer computer);
        IEnumerable<ComInfo> GetComputersInfo();
    }
}
