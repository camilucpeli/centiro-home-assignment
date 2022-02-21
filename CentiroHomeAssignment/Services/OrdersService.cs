using CentiroHomeAssignment.Models;
using CentiroHomeAssignment.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Services
{

    public class OrdersService
    {
        private IRepository<Order> _repo { get; set; }

        public OrdersService(IRepository<Order> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(string orderNumber)
        {
            return await _repo.GetByIdAsync(orderNumber);
        }
    }
}
