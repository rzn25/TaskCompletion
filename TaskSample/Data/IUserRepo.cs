using System.Collections.Generic;
using TaskSample.Models;

namespace TaskSample.Data
{
    public interface IUserRepo
    {
        bool SaveChanges();

        IEnumerable<User> GetAllUsers();

        IEnumerable<User> GetUserByGroup(string group);

        void CreateUser(User user);
    }
}