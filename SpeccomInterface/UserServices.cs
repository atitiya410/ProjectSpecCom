﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SpeccomDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace SpeccomInterface
{
    public class UserServices : IUser
    {
        private readonly speccomContext _context;
        public UserServices(speccomContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var item = _context.User;
            return item;
        }

        public User GetUserByID(int id)
        {
            return _context.User.SingleOrDefault(m => m.UserId == id);
        }
        public void PutUser(int id, User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public User AddUser(User user)
        {

            var username = _context.User.SingleOrDefault(a => a.UserName == user.UserName);
            if (username == null)
            {
                _context.User.Add(user);
                _context.SaveChanges();

            }
            else
            {
                user.UserId =username.UserId;
            }
            
            return user;
        }

       

        //public void DeleteUserByID(int id)
        //{
        //    var user =  _context.User.SingleOrDefaultAsync(m => m.UserId == id);
        //    if (user == null)
        //    {

        //    }
        //    else
        //    {
        //        _context.User.Remove(user);
        //        _context.SaveChangesAsync();
        //    }

           
          
        //}
    }
}
