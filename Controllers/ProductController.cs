using Microsoft.AspNetCore.Mvc;

namespace DiplomeProject.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok();
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById()
        {
            return Ok();
        }

        [HttpGet("GetProductsByCategory/{category}")]
        public async Task<IActionResult> GetProductsByCategory()
        {
            return Ok();
        }
    }
}
