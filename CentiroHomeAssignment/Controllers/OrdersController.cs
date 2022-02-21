using CentiroHomeAssignment.Models;
using CentiroHomeAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Controllers
{
    public class OrdersController : Controller
    {
        private OrdersService _service { get; set; }
        
        public OrdersController(OrdersService service)
        {
            _service = service;
        }


        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _service.GetAllOrdersAsync();
        }

        public async Task<Order> GetByOrderNumber(string orderNumber)
        {
            return await _service.GetOrderByIdAsync(orderNumber);
        }

    }
}
