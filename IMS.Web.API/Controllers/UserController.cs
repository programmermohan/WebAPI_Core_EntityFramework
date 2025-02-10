using IMS.Web.Business.Interfaces;
using IMS.Web.Business.ModelEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser([FromBody] User user)
        {
            try
            {
                bool isuserAdded = _userService.AddUser(user);
                if (isuserAdded)
                    return StatusCode(StatusCodes.Status200OK, isuserAdded);
                else
                    return StatusCode(StatusCodes.Status200OK, "User not added");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while getting adding user");
            }
        }
    }
}
