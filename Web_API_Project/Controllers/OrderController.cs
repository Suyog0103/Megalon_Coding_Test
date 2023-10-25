using Megalon.DAL;
using Megalon.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web_API_Project.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly CustomerOrdersDB _context;

        public OrdersController(CustomerOrdersDB context)
        {
            _context = context;
        }

      
        [HttpGet("{customerId}")]
        public ActionResult<IEnumerable<Order>> GetOrders(Guid customerId)
        {
            var orders = _context.Orders
                .Where(o => o.CustomerID == customerId)
                .ToList();

            return Ok(orders); 
        }
    }
}
