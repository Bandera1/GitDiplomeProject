using DiplomeProject.DB;
using DiplomeProject.DB.IdentityModels;
using DiplomeProject.DB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiplomeProject.Controllers
{
    public class TestController : ApiController
    {
        private readonly UserManager<DbUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public TestController(UserManager<DbUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("SeedAdmin")]
        public async Task<IActionResult> SeedAdmin()
        {
            var admin = new DbUser
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin",
                Email = "admin@gmail.com",
                UserName = "admin", 
                Age = "20",
                Surname = "admin"
                
            };

            await _roleManager.CreateAsync(new IdentityRole
            {
                Name = ProjectRoles.ADMIN
            });
            var res1 = await _userManager.CreateAsync(admin, "Qwerty-1");
            var res2 = await _userManager.AddToRoleAsync(admin, ProjectRoles.ADMIN);

            return Ok(res1);
        }
    }
}
