
using Microsoft.AspNetCore.Mvc;

namespace Lab.APIGateway.User.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUser(int userId)
        {
            if (userId <= 0)
            {
                return BadRequest("Invalid userId");
            }

            var user = userService.GetUserById(userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }
    }
}