using CentiroHomeAssignment.Services;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAllAsync()
        {
            var orders = await _service.GetAllOrdersAsync();

            return View(orders);
        }

        // GET: api/Orders/2
        [HttpGet("~/orders/GetByOrderNumber/{orderNumber}")]
        public async Task<IActionResult> GetByOrderNumber(int orderNumber)
        {
            var order = await _service.GetOrderByIdAsync(orderNumber);
            return View(order);
        }

        public IActionResult Edit()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Delete()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Create()
        {
            throw new System.NotImplementedException();
        }
    }
}
