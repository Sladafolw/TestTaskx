using Microsoft.EntityFrameworkCore;
using System;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;

namespace TestTask.Services.Interfaces
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context=context;
        }
        public Task<VMUser> GetUser()
        {
             return Task.Run(() =>
             {
                 var user = _context.Users.Include(u => u.Orders).OrderByDescending(x => x.Orders.Count).First();
                 VMUser vmUser = new()
                    { Email = user.Email, Id = user.Id, Status = user.Status, NumberOfOrders = user.Orders.Count() };
                return vmUser;
            });
        }

        public Task<List<User>> GetUsers()
        {
            return _context.Users.Where(x => x.Status == UserStatus.Inactive).ToListAsync();
        }
    }
}
