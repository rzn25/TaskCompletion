using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TaskSample.Data;
using TaskSample.Models;

namespace TaskSample.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public UserService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public bool ValidateCredentials(string username, string password)
        {

            Console.WriteLine($"Username: {_configuration["AuthUserName"]} Password: {_configuration["AuthPassword"]}");

           return username.Equals(_configuration["AuthUserName"]) && password.Equals(_configuration["AuthPassword"]);
        }
    }
}