using CentiroHomeAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Repositories
{
    public class OrdersRepository : BaseRepository<Order>
    {
        private DbSet<Order> _dbSet { get; set; }

        public OrdersRepository(CentiroHomeAssignmentContext context) : base(context)
        {
            _dbSet = context.Set<Order>();
        }

        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _dbSet
                .Include(order => order.Customer)
                .Include(order => order.OrderDetails).ThenInclude(orderDetail => orderDetail.Product).ToListAsync();
        }

        public override async Task<Order> GetByIdAsync(object orderNumber)
        {
            if (int.TryParse(orderNumber.ToString(), out var orderNumberInt))
            {
                return await _dbSet
                    .Include(order => order.Customer)
                    .Include(order => order.OrderDetails).ThenInclude(orderDetail => orderDetail.Product)
                    .FirstOrDefaultAsync(order => order.OrderNumber == orderNumberInt);
            }

            return null;
        }
    }
}