using DiplomeProject.DB;
using DiplomeProject.DB.Models;
using DiplomeProject.Repositories.Interfaces;

namespace DiplomeProject.Repositories.Implementations
{
    public class ProducerRepository : IRepository<Producer>
    {
        public readonly EFDbContext _context;

        public ProducerRepository(EFDbContext context)
        {
            _context = context;
        }

        public void Delete(string EntityId)
        {
            _context.Producers.Remove(GetById(EntityId));

            Save();
        }

        public IEnumerable<Producer> GetAll()
        {
            return _context.Producers.ToList();
        }

        public Producer GetById(string EntityId)
        {
            return _context.Producers.FirstOrDefault(x => x.Id == EntityId);
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public void Insert(Producer entity)
        {
            if (entity == null)
            {
                return;
            }

            _context.Producers.Add(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
