using DiplomeProject.DB.Models;
using DiplomeProject.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiplomeProject.Controllers
{
    [Authorize("admin")]
    public class AdminController : ApiController
    {
        private readonly IRepository<Product> _productRepository;

        public AdminController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> AddNewProduct([FromBody]Product newProduct)
        {
            return Ok();
        }

        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody]Product product)
        {
            return Ok();
        }

        [HttpPost("RemoveProduct")]
        public async Task<IActionResult> RemoveProduct([FromBody] Product product)
        {
            return Ok();
        }
    }
}
