using SpeccomDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeccomInterface
{
    public interface IUser
    {
        IEnumerable<User> GetAllUsers();
        User GetUserByID(int id);
        void PutUser(int id, User user);
        User AddUser(User user);
        //void DeleteUserByID(int id);
       
    }
}
