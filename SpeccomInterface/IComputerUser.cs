using System;
using System.Collections.Generic;
using System.Text;
using WebapiSpeccom.Models;

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
