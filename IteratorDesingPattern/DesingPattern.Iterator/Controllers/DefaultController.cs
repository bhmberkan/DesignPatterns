using DesingPattern.Iterator.IteratorPattern;
using Microsoft.AspNetCore.Mvc;

namespace DesingPattern.Iterator.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {

            VisitRouteMover VisitRouteMover = new VisitRouteMover();
            List<string> strings = new List<string>();

            VisitRouteMover.AddVisitRoute(new VisitorRoute { CountrName = "Almanya",CityName="Berlin", VisitPlaceName="Berlin Kapısı" });
            VisitRouteMover.AddVisitRoute(new VisitorRoute { CountrName = "Fransa",CityName="Paris", VisitPlaceName="Eyfel" });
            VisitRouteMover.AddVisitRoute(new VisitorRoute { CountrName = "İtalya",CityName="Venedik", VisitPlaceName="Gondol" });
            VisitRouteMover.AddVisitRoute(new VisitorRoute { CountrName = "İtalya",CityName="Roma", VisitPlaceName="Kolezyum" });
            VisitRouteMover.AddVisitRoute(new VisitorRoute { CountrName = "Çek Cumhuriyeti",CityName="Prag", VisitPlaceName="Meydan" });

            var iterator = VisitRouteMover.CreatorIterator();

            while (iterator.NextLocation())
            {
                strings.Add(iterator.CurrentItem.CountrName + " " + iterator.CurrentItem.CityName + " " + iterator.CurrentItem.VisitPlaceName);
            }

            ViewBag.v = strings;

            return View();
        }
    }
}
