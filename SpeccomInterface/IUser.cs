using SpeccomDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeccomInterface
{
    public interface IUser
    {
        object GetAllUsers();
        IQueryable<User> GetUserByID(int id);
        void PutUser(int id, User user);
        User AddUser(User user);
        //void DeleteUserByID(int id);
       
    }
}
