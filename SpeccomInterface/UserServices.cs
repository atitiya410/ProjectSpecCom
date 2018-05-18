using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebapiSpeccom.Models;

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
            return _context.User;
        }

        public User GetUserByID(int id)
        {
            return _context.User.SingleOrDefault(m => m.UserId == id);
        }
        public void PutUser(int id, User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public async void AddUser(User user)
        {
            var username = await _context.User.SingleOrDefaultAsync(a => a.UserName == user.UserName);
            if (username == null)
            {
                _context.User.Add(user);
                await _context.SaveChangesAsync();

            }
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
