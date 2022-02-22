using CentiroHomeAssignment.Models;
using CentiroHomeAssignment.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Services
{

    public class OrdersService
    {
        private OrdersRepository _repo { get; }

        public OrdersService(OrdersRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderNumber)
        {
            var result = await _repo.GetByIdAsync(orderNumber);
            return result;
        }
    }
}
