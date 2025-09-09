using DesignPattern.Facade.DAL;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Facade.Controllers
{
    public class CustomerController : Controller
    {
        Context context = new Context();
        [HttpGet]
        public IActionResult AddNewCustomer()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddNewCustomer(Customer customer)
        {
            context.customers.Add(customer);
            context.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        public IActionResult CustomerList()
        {
            var values = context.customers.ToList();
            return View(values);
        }



    }
}
