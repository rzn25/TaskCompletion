using System.Threading.Tasks;
using TaskSample.Models;

namespace TaskSample.Services
{
    public interface IUserService
    {
        bool ValidateCredentials(string username, string password);
    }
}