using DiplomeProject.DB.Models;
using DiplomeProject.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiplomeProject.Controllers.UserControler
{
    public class ProducerController : ApiController
    {
        private readonly IRepository<Producer> _producerRepository;

        public ProducerController(IRepository<Producer> productRepository)
        {
            _producerRepository = productRepository;
        }

        [HttpGet("GetAllProducers")]
        public async Task<IActionResult> GetAllProducers()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_producerRepository.GetAll());
        }
    }
}
