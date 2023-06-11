using DiplomeProject.DB;
using DiplomeProject.DB.Models;

namespace DiplomeProject.Services
{
    public class CategoryService
    {
        public readonly EFDbContext _context;

        public CategoryService(EFDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(string id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public bool CreateCategory(Category category)
        {
            if (category == null) return false;

            _context.Categories.Add(category);
            _context.SaveChanges();
            return true;
        }
    }
}
