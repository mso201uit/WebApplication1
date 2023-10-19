using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            List<Product> products = new List<Product>{
            new Product {Name="Hammer", Price=121.50m, CategoryId=1},
            new Product {Name="Vinkelsliper", Price=1520.00m, CategoryId =1},
            new Product {Name="Melk", Price=14.50m, CategoryId =3},
            new Product {Name="Kjøttkaker", Price=32.00m, CategoryId =3},
            new Product {Name="Brød", Price=25.50m, CategoryId =3}
            };

            return View(products);
        }
        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product Product)
        {
            try
            {
                // Kall til metoden save i repository
                this.Save(Product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public void Save(Product product)
        {
            throw new NotImplementedException();
        }
        private IProductRepository repository;
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }
    }
}
