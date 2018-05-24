using SpeccomDB.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace SpeccomInterface
{
    public interface IComputerUser
    {
        IEnumerable<ComputerUser> GetComputerUser();
        ComputerUser GetCompuerUserByID(int id);
        void PutComputerUser(int id, ComputerUser computerUser);
        void AddComputerUser(ComputerUser computerUser);
    }
}
