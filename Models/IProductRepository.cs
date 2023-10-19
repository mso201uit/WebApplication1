using WebApplication1.Models.Entities;

namespace WebApplication1.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        public void Save(Product product);
    }

    
}
