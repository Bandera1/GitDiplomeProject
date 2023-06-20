using DiplomeProject.DB;
using DiplomeProject.DB.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentAccountingProject.Services
{
    public interface IJwtTokenService
    {
        Task<string> CreateToken(DbUser user);
    }

    public class JwtTokenService : IJwtTokenService
    {
        private readonly UserManager<DbUser> _userManager;
        private readonly EFDbContext _context;
        private readonly IConfiguration _configuration;
        public JwtTokenService(UserManager<DbUser> userManager, EFDbContext context,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _userManager = userManager;
            _context = context;
        }
        public async Task<string> CreateToken(DbUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            roles = roles.OrderBy(x => x).ToList();
            var query = _context.Users.AsQueryable();         


            List<Claim> claims = new List<Claim>()
            {
                new Claim("id",user.Id),
                new Claim("name",user.UserName),
            };
            foreach (var el in roles)
            {
                claims.Add(new Claim("roles", el));
            }

            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("a8f5f167f44f4964e6c998dee827110c"));
            var signinCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                signingCredentials: signinCredentials,
                expires: DateTime.Now.AddDays(1),
                claims: claims
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
