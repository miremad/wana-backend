using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;
using Service.UserService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginTemplate.Controllers.UserController
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("getUserByUsername")]
        public async Task<UserDetailDto> getUserByUsername(string username)
        {
            return await userService.getUser(username);
        }

        [HttpGet("getCurrentUser")]
        public async Task<UserDetailDto> getCurrentUser()
        {
            return await userService.getCurrentUser();
        }

    }
}
