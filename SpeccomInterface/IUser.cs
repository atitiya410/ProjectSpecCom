using System;
using System.Collections.Generic;
using System.Text;
using WebapiSpeccom.Models;

namespace SpeccomInterface
{
    public interface IUser
    {
        IEnumerable<User> GetAllUsers();
        User GetUserByID(int id);
        void PutUser(int id, User user);
        void AddUser(User user);
        //void DeleteUserByID(int id);
       
    }
}
