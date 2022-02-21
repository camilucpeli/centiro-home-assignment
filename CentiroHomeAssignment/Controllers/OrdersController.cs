using CentiroHomeAssignment.Models;
using CentiroHomeAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : Controller
    {
        private OrdersService _service { get; set; }
        
        public OrdersController(OrdersService service)
        {
            _service = service;
        }

        // GET: api/Orders
        [HttpGet("~/orders")]
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _service.GetAllOrdersAsync();
        }

        // GET: api/Orders/2
        [HttpGet("{orderNumber}")]
        public async Task<Order> GetByOrderNumber(string orderNumber)
        {
            return await _service.GetOrderByIdAsync(orderNumber);
        }

    }
}
