using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;

namespace TestTask.Services.Interfaces
{
    public class OrderService : IOrderService
    {
        private ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<Order> GetOrder()
        {
            return _context.Orders.OrderByDescending(l => l.Quantity * l.Price).FirstAsync();
        }

        public Task<List<Order>> GetOrders()
        {
            return _context.Orders.Where(x => x.Quantity > 10).ToListAsync();
        }
    }
}
