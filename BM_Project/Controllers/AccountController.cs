using BMEmployee.Core.DTO;
using BMEmployee.Core.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BMEmployee.UI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration config;

        public AccountController(UserManager<AppUser> UserManager, IConfiguration config)
        {
            _userManager = UserManager;
            this.config = config;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto UserFromReq)
        {
            if (ModelState.IsValid) 
            {
               AppUser user = new AppUser();
                user.UserName=UserFromReq.UserName;
                user.Email = UserFromReq.Email;
              IdentityResult result = await _userManager.CreateAsync(user, UserFromReq.Password);
                if (result.Succeeded) 
                {
                    return Ok("Created");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("Password", item.Description);
                }
            }
            return BadRequest(ModelState);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto UserFromReq)
        {
            if (ModelState.IsValid) 
            {
              AppUser userfromDB = await _userManager.FindByNameAsync(UserFromReq.UserName);
                if(userfromDB != null)
                {
                bool found = await _userManager.CheckPasswordAsync(userfromDB, UserFromReq.Password);
                    if (found == true)
                    {
                        //generate token

                        List<Claim> UserCalims = new List<Claim>();
                        //token generated id change (JWT predefind Claims)
                        UserCalims.Add(new Claim(JwtRegisteredClaimNames.Jti,
                            Guid.NewGuid().ToString()));

                        UserCalims.Add(new Claim(ClaimTypes.NameIdentifier, userfromDB.Id));
                        UserCalims.Add(new Claim(ClaimTypes.Name, userfromDB.UserName));

                        var UserRole = await _userManager.GetRolesAsync(userfromDB);

                        foreach (var roleName in UserRole) 
                        {
                            UserCalims.Add(new Claim(ClaimTypes.Role, roleName));
                        }

                        var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecritKey"]));

                        SigningCredentials signingCred = 
                            new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256);

                        //design token
                        JwtSecurityToken mytoken = new JwtSecurityToken(
                                audience: config["JWT:AudienceIP"],
                                issuer: config["JWT:IssuerIP"],
                                expires: DateTime.Now.AddHours(2),
                                claims: UserCalims,
                                signingCredentials: signingCred
                            );
                        //generate token response
                        return Ok(new
                        {
                             token = new JwtSecurityTokenHandler().WriteToken(mytoken),
                             expiration = DateTime.Now.AddHours(2) //mytoken.ValidTo
                        });
                    }
                }
                ModelState.AddModelError("Username", "Username OR Password Invalid");
            }
            return BadRequest(ModelState);
        }
    }
}
