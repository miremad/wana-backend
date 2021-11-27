using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Model.Model;
using Model.ViewModel;
using Service.JWT;
using Service.UserService;

namespace LoginTemplate.Controllers.Account
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;
        private readonly JwtSettings _jwtsettings;

        public AccountController(
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            IUserService _userService,
            IOptions<JwtSettings> jwtsettings)
        {
            signInManager = _signInManager;
            userManager = _userManager;
            userService = _userService;
            _jwtsettings = jwtsettings.Value;
        }

        [HttpPost("createUser")]
        public async Task<IdentityResult> CreateUser(CreateUserDto userModel)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = userModel.UserName,
                City = userModel.City,
                Email = userModel.Email,
                PhoneNumber = userModel.PhoneNumber


            };
            var res = await userManager.CreateAsync(user, userModel.Password);
            return res;
        }

        [HttpPost("login")]
        public async Task<UserLoginResponseDto> Login(UserLoginDto userModel)
        {
            return await userService.login(userModel);
        }

        

    }
}
