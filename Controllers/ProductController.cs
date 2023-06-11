using DiplomeProject.DB.Models;
using DiplomeProject.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiplomeProject.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IRepository<Product> _productRepository;

        public ProductController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository; 
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_productRepository.GetAll());
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_productRepository.GetById(id));
        }


        [HttpGet("GetProductsByCategory/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(string categoryId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_productRepository.GetAll().Where(x => x.CategoryId == categoryId));
        }

        [HttpGet("GetProductsByProducer/{producerId}")]
        public async Task<IActionResult> GetProductsByProducer(string producerId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_productRepository.GetAll().Where(x => x.ProducerId == producerId));
        }
    }
}
