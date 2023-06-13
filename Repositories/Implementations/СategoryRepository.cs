using DiplomeProject.DB;
using DiplomeProject.DB.Models;
using DiplomeProject.Repositories.Interfaces;

namespace DiplomeProject.Repositories.Implementations
{
    public class СategoryRepository : IRepository<Category>
    {
        public readonly EFDbContext _context;

        public СategoryRepository(EFDbContext context)
        {
            _context = context;
        }

        public void Delete(string EntityId)
        {
            _context.Categories.Remove(GetById(EntityId));

            Save();
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(string EntityId)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == EntityId);
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public void Insert(Category entity)
        {
            if (entity == null)
            {
                return;
            }

            _context.Categories.Add(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
