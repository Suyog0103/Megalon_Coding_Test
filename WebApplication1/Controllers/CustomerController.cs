using Microsoft.AspNetCore.Mvc;
using Megalon.DAL; 
using Megalon.Models; 
 
public class CustomerController : Controller
{
    private readonly CustomerOrdersDB _context;

    public CustomerController(CustomerOrdersDB context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult CustomerTable()
    {
        List<Customer> customers = _context.Customers.ToList();
        return View(customers);
    }
}
