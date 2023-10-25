using Megalon.DAL;
using Megalon.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web_API_Project.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerOrdersDB _context;

        public CustomerController(CustomerOrdersDB context)
        {
            _context = context;
        }

       
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            try
            {
                List<Customer> customers = _context.Customers.ToList();
                if (customers == null || customers.Count == 0)
                {
                    return NotFound("No customers found");
                }
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}