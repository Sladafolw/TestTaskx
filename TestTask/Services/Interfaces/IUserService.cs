using TestTask.Models;

namespace TestTask.Services.Interfaces
{
    public interface IUserService
    {
        public Task<VMUser> GetUser();

        public Task<List<User>> GetUsers();
    }
}
