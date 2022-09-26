using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Model;
using Model.ViewModel;
using Repository;
using Service.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IJwtManager jwtManager;
        private readonly AppDBContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserRepo userRepo;

        public UserService(
            IJwtManager _jwtManager, 
            AppDBContext _context, 
            UserManager<ApplicationUser> _userManager, 
            IUserRepo _userRepo)
        {
            jwtManager = _jwtManager;
            context = _context;
            userManager = _userManager;
            userRepo = _userRepo;
        }
        public async Task<UserLoginResponseDto> login(UserLoginDto userModel)
        {
            UserLoginResponseDto userLoginResponse = new UserLoginResponseDto();

            var user = userManager.Users.SingleOrDefault(x => x.UserName == userModel.UserName);
            if (user is null)
            {
                return null;
            }

            var userSigninResult = await userManager.CheckPasswordAsync(user, userModel.Password);
            if (userSigninResult)
            {
                var roles = await context.UserRoles.Where(x => x.UserId == user.Id).Select(c => c.RoleId).ToListAsync();
                var userRoles = context.Roles.Where(x => roles.Contains(x.Id)).Select(c => c.Name).ToArray();
                userLoginResponse.Token = jwtManager.Authentication(user.Id.ToString(), userModel.UserName, userModel.Password, userRoles);
                return userLoginResponse;
            }

            return userLoginResponse;

        }

        public async Task<UserDetailDto> getUser(string username)
        {
            return await userRepo.getUser(username);
        }

        public async Task<UserDetailDto> getCurrentUser()
        {
            
            return await userRepo.getCurrentUser();
        }
    }
}
