using DiplomeProject.DB.IdentityModels;
using DiplomeProject.Services;
using DiplomeProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiplomeProject.Controllers.Auth
{
    public class AccountController : ApiController
    {
        private readonly AuthService _authService;

        public AccountController(AuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("LoginUser")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var res = await _authService.LoginUser(model);

            if(res == null)
            {
                return BadRequest(res);
            }

            return Ok(res);
        }
    }
}
