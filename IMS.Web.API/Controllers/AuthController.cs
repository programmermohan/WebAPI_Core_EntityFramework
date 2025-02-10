using IMS.Web.API.Services;
using IMS.Web.Business.Interfaces;
using IMS.Web.Business.ModelEntities;
using IMS.Web.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IMS.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _role;
        private readonly ITokenService _tokenService;
        public AuthController(IUserService userService,IRoleService role, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _userService = userService;
            _role = role;
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] UserModel UserModel)
        {
            if(UserModel == null)
            {
                return BadRequest("Invalid client request");
            }

            var user = _userService.GetUser(UserModel.UserName, UserModel.Password);
            if(user == null)
            {
                return Unauthorized();
            }
            var role = _role.GetUserRole(UserModel.UserName);
            var claims = new List<Claim>
            {
              new Claim(ClaimTypes.Name, UserModel.UserName),
              new Claim(ClaimTypes.Role, role.RoleName)
            };

            var accessToken = _tokenService.GenerateToken(claims);

            return Ok(new
            {
                Token = accessToken
            });
        }
    }
}
