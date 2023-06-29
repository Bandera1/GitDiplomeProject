using DiplomeProject.DB.IdentityModels;
using DiplomeProject.DB;
using Microsoft.AspNetCore.Identity;
using StudentAccountingProject.Services;
using Azure.Core;
using DiplomeProject.ViewModels;

namespace DiplomeProject.Services
{
    public class AuthService
    {

        private readonly EFDbContext Context;
        private readonly UserManager<DbUser> UserManager;
        private readonly SignInManager<DbUser> SignInManager;
        private readonly IJwtTokenService IJwtTokenService;

        public AuthService(EFDbContext context, UserManager<DbUser> userManager, SignInManager<DbUser> signInManager, IJwtTokenService iJwtTokenService)
        {
            Context = context;
            UserManager = userManager;
            SignInManager = signInManager;
            IJwtTokenService = iJwtTokenService;
        }

        public async Task<string> LoginUser(LoginViewModel model)
        {
            var user = Context.Users.FirstOrDefault(x => x.Email == model.Email);
            if (user == null)
            {
                return null;
            }

            var result = await SignInManager
                .PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }

            var token = await IJwtTokenService.CreateToken(user);
            await SignInManager.SignInAsync(user, isPersistent: false);
            return token;
        }
    }
}
