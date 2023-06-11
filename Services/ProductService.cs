using DiplomeProject.DB;
using DiplomeProject.DB.Models;

namespace DiplomeProject.Services
{
    public class ProductService
    {
        public readonly EFDbContext _context;

        public ProductService(EFDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public List<Product> GetByCategory(Category category)
        {
            return _context.Products.Where(x => x.Category == category).ToList();
        }

        public List<Product> GetByStatus(ProductStatus status)
        {
            return _context.Products.Where(x => x.Status == status).ToList();
        }

        public List<Product> GetByProducer(Producer producer)
        {
            return _context.Products.Where(x => x.Producer == producer).ToList();
        }

        public Product GetById(string id) => _context.Products.FirstOrDefault(x => x.Id == id) ?? null;

        public bool CreateProduct(Product product)
        {
            if (product == null) return false;

            _context.Products.Add(product);
            _context.SaveChanges();
            return true;
        }
    }
}
