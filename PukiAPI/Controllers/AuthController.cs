using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PukiAPI.Data;
using PukiAPI.Models.DTO.LoginDTOs;
using PukiAPI.Models.DTO.RegisterDTO;
using PukiAPI.Repositories.TokenRepo;

namespace PukiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository )
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegDTO registerDTO)
        {
            var identityUser = new IdentityUser()
            {
                UserName = registerDTO.Username,
                Email = registerDTO.Username
            };
         var  identityResult= await userManager.CreateAsync(identityUser, registerDTO.Password);
        
        if(identityResult.Succeeded)
            {
                // Add Roles to this user
                if(registerDTO.Roles!=null && registerDTO.Roles.Any())
                {
                identityResult=await userManager.AddToRolesAsync(identityUser, registerDTO.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered!, Please login!");
                    }
                }
            }
            return BadRequest("Something went wrong!");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginDTO loginDTO)
        {
            var user=await userManager.FindByEmailAsync(loginDTO.Username);
            if(user!=null)
            {
                var checkPassword=await userManager.CheckPasswordAsync(user,loginDTO.Password);
                if (checkPassword)
                {
                    var roles=await userManager.GetRolesAsync(user);
                    if(roles!=null)
                    {
                        //CreateToken
                      var jwtToken=tokenRepository.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDTO()
                        {
                            JwtToken = jwtToken,
                            roles = roles.ToList()
                        };
                        return Ok(response);
                    }
                    
                }
            }
            return BadRequest("Username or password incorect");
        }
    }
}
