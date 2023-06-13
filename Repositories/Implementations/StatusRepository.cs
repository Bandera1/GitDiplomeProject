using DiplomeProject.DB;
using DiplomeProject.DB.Models;
using DiplomeProject.Repositories.Interfaces;

namespace DiplomeProject.Repositories.Implementations
{
    public class StatusRepository : IRepository<ProductStatus>
    {
        public readonly EFDbContext _context;

        public StatusRepository(EFDbContext context)
        {
            _context = context;
        }

        public void Delete(string EntityId)
        {
            _context.ProductStatuses.Remove(GetById(EntityId));

            Save();
        }

        public IEnumerable<ProductStatus> GetAll()
        {
            return _context.ProductStatuses.ToList();
        }

        public ProductStatus GetById(string EntityId)
        {
            return _context.ProductStatuses.FirstOrDefault(x => x.Id == EntityId);
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public void Insert(ProductStatus entity)
        {
            if (entity == null)
            {
                return;
            }

            _context.ProductStatuses.Add(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
