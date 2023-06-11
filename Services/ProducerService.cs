using DiplomeProject.DB;
using DiplomeProject.DB.Models;

namespace DiplomeProject.Services
{
    public class ProducerService
    {
        public readonly EFDbContext _context;

        public ProducerService(EFDbContext context)
        {
            _context = context;
        }

        public List<Producer> GetAll()
        {
            return _context.Producers.ToList();
        }

        public Producer GetById(string id)
        {
            return _context.Producers.FirstOrDefault(x => x.Id == id);
        }

        public bool CreateProducer(Producer producer)
        {
            if (producer == null) return false;

            _context.Producers.Add(producer);
            _context.SaveChanges();
            return true;
        }
    }
}
