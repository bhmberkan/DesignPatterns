using DesignPattern.ChainOfResponsibility.ChainOfResponsibilitiy;
using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.ChainOfResponsibility.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            Employee treasurer = new Treasurer();
            Employee managerAssistant = new ManagerAsistant();
            Employee manager = new ManagerAsistant();
            Employee areaDirector = new AreaDirector();

            treasurer.SetNextApprover(managerAssistant);
            managerAssistant.SetNextApprover(manager);
            manager.SetNextApprover(areaDirector);

            /*
            // manager asistant yoksa bu şekilde kontrol sağlanabilir.
            treasurer.SetNextApprover(manager);
           // managerAssistant.SetNextApprover(manager);
            manager.SetNextApprover(areaDirector);
            */
            treasurer.ProccesRequest(model);



            return View();
        }
    }
}
