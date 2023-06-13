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

        [HttpGet("GetAllProducts/{from}/{count}/{producerId}/{name}")]
        public async Task<IActionResult> GetAllProducts(int from, int count, string? producerId, string? name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var allProducts = _productRepository.GetAll();
            int productCount = _productRepository.GetCount();

            if(from + count > productCount)
            {
                return Ok(allProducts.Take(count));
            }

            var result = _productRepository.GetAll(); 

            if (producerId != null && producerId != "0")
            {
                result = result.Where(x => x.ProducerId == producerId);
            }

            if (name != null && name != "0")
            {
                result = result.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            }

            //if (article != null && article != "0")
            //{
            //    result = result.Where(x => x.Article == article);
            //}

            //if (categoriesId != null)
            //{
            //    foreach (var category in categoriesId)
            //    {
            //        result.ToList().AddRange(allProducts.Where(x => x.CategoryId == category));
            //    }
            //}


            return Ok(result.Skip(from).Take(count));
        }

        [HttpGet("GetProductsCounts")]
        public async Task<IActionResult> GetProductsCounts()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_productRepository.GetAll().Count());
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
