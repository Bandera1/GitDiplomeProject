using DiplomeProject.DB;
using DiplomeProject.DB.Models;
using DiplomeProject.Repositories.Interfaces;
using StudentAccountingProject.Helpers;
using System.Data.Entity;

namespace DiplomeProject.Repositories.Implementations
{
    public class ProductRepository : IRepository<Product>
    {
        public readonly EFDbContext _context;

        public ProductRepository(EFDbContext context)
        {
            _context = context;
        }

        public void Delete(string EntityId)
        {
            _context.Products.Remove(GetById(EntityId));

            Save();
        }

        public IEnumerable<Product> GetAll()
        {
            var products = _context.Products;

            products.ToList().ForEach(x =>
            {
                x.PhotoBase64 = ImageService.ImageToBase64(x.PhotoPath);
            });

            return products;
        }

        public Product GetById(string EntityId)
        {
            return _context.Products.FirstOrDefault(x => x.Id == EntityId);
        }

        public void Insert(Product entity)
        {
            if (entity == null)
            {
                return;
            }

            _context.Products.Add(entity);
            Save();
        }

        public int GetCount()
        {
            return _context.Products.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
