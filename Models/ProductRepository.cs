using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models
{
    public class ProductRepository : IProductRepository
    {

        private ApplicationDbContext db;
        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Product> GetAll()
        {
            var products = db.Product;
            return products;
        }

        public void Save(Product product)
        {
            if (product.ProductId == 0)
            {
                // If the product is new, add it to the DbSet
                db.Product.Add(product);
            }
            else
            {
                // If the product exists, mark it as modified
                db.Entry(product).State = EntityState.Modified;
            }
            db.SaveChanges(); // Commit the changes

        }
    }

}
