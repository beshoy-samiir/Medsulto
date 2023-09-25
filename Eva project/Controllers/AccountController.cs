using Eva_project.DTOS;
using Eva_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Eva_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;

        public AccountController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDTO newUserDto)
        {
            User appUser = new User();
            appUser.UserName = newUserDto.UserName;
            appUser.PasswordHash = newUserDto.Password;
            appUser.Address = newUserDto.Address;
            IdentityResult result =
                await userManager.CreateAsync(appUser, appUser.PasswordHash);
            if (result.Succeeded)
                return Ok("Created");
            else
                return BadRequest(result.Errors.ToList());
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDTO newUser, [FromServices] IConfiguration config)
        {
            User appUserModel = await userManager.FindByNameAsync(newUser.Name);
            if (appUserModel != null)
            {
                bool found = await userManager.CheckPasswordAsync(appUserModel, newUser.Password);
                if (found)
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, newUser.Name));
                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    var symKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]));
                    var signInCredentials = new SigningCredentials(symKey, SecurityAlgorithms.HmacSha256);
                    JwtSecurityToken UserToken = new JwtSecurityToken(
                        issuer: config["JWT:Issues"],
                        audience: config["JWT:Audiance"],
                        expires: DateTime.Now.AddHours(1),
                        claims: claims,
                        signingCredentials: signInCredentials
                        );
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(UserToken),
                        expiration = UserToken.ValidTo
                    });
                }
            }
            return Unauthorized("Invalid Account");
        }
    }
}
