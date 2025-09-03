using DesignPatter.Composite.DAL;
using DesignPattern.Composite.CompositePattern;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Composite.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Context _context;

        public DefaultController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.categories.Include(x => x.products).ToList();
            var values = Rekursive(categories, new Category { CategoryName = "FirstCategory", CategoryID = 0 }, new ProductComposite(0, "FirstComposite"));
            ViewBag.v = values;
            return View();
        }

        public ProductComposite Rekursive(List<Category> categories, Category firstCategory, ProductComposite firstComposite, ProductComposite leaf = null)
        {
            categories.Where(x => x.UpperCategoryID == firstCategory.CategoryID).ToList().ForEach(y =>
            {
                var productComposite = new ProductComposite(y.CategoryID, y.CategoryName);

                y.products.ToList().ForEach(z =>
                {
                    productComposite.Add(new ProductComponent(z.ProductID, z.ProductName));
                });

                if (leaf != null)
                {
                    leaf.Add(productComposite);
                }
                else
                {
                    firstComposite.Add(productComposite);
                }
                Rekursive(categories, y, firstComposite, productComposite);
            });
            return firstComposite;
        }
    }
}
