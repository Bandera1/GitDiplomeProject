using DiplomeProject.DB.Models;
using DiplomeProject.Repositories.Implementations;
using DiplomeProject.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiplomeProject.Controllers.UserControler
{
    public class CategoryController : ApiController
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_categoryRepository.GetAll());
        }
    }
}
