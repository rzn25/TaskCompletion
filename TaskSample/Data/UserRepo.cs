using System;
using System.Collections.Generic;
using System.Linq;
using TaskSample.Models;

namespace TaskSample.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public IEnumerable<User> GetUserByGroup(string group)
        {
            return _context.Users.Where(x => x.GroupName.ToLower() == group.ToLower());
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}