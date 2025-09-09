using DesignPattern.Facade.DAL;
using DesignPattern.Facade.FacadePattern;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Facade.Controllers
{
    public class OrderController : Controller
    {
        Context context = new Context();

        [HttpGet]
        public IActionResult OrderDetailStart()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OrderDetailStart(int CustomerID, int ProductID, int OrderID, int ProductCount, decimal ProductPrice)
        {
            OrderFacade order = new OrderFacade();
            order.CompleteOrderDetail(CustomerID, ProductID, OrderID, ProductCount, ProductPrice);
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public IActionResult OrderStart()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OrderStart(int customerID)
        {
            OrderFacade orderFacade = new OrderFacade();
            orderFacade.CompleteOrder(customerID);
            return RedirectToAction("OrderDetailStart");
        }

        public IActionResult Index()
        {
            var values = context.orderDetails.ToList();
            return View(values);
        }

        public IActionResult Orders()
        {
            var values = context.orders.ToList();
            return View(values);
        }
    }
}
