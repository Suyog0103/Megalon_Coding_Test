
using Microsoft.AspNetCore.Mvc;
using Megalon.DAL; 
using Megalon.Models; 

namespace WebApplication1.Controllers
{
    public class OrdersController : Controller
    {
        private readonly CustomerOrdersDB _context;

        public OrdersController(CustomerOrdersDB context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetOrders(Guid customerId)
        {
            
            List<Order> orders = _context.Orders
                .Where(o => o.CustomerID == customerId)
                .ToList();

            
            return View(orders);
        }
    }
}
