using DiplomeProject.DB;
using DiplomeProject.DB.Models;

namespace DiplomeProject.Services
{
    public class StatusService
    {
        public readonly EFDbContext _context;

        public StatusService(EFDbContext context)
        {
            _context = context;
        }

        public List<ProductStatus> GetAll()
        {
            return _context.ProductStatuses.ToList();
        }

        public ProductStatus GetById(string id)
        {
            return _context.ProductStatuses.FirstOrDefault(x => x.Id == id);
        }

        public bool CreateStatus(ProductStatus status)
        {
            if (status == null) return false;

            _context.ProductStatuses.Add(status);
            _context.SaveChanges();
            return true;
        }
    }
}
