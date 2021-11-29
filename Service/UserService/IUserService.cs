using Model.Model;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.UserService
{
    public interface IUserService
    {
        Task<UserLoginResponseDto> login(UserLoginDto userModel);

        Task<UserDetailDto> getUser(string username);

        Task<UserDetailDto> getCurrentUser();

    }
}
