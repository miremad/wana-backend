using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.User
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;
        public UserRepo(AppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<UserDetailDto> getUser(string username)
        {
        
            var user = await _dbContext.Users.Where(u => u.UserName == username).ProjectTo<UserDetailDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            return user;
        }

        public async Task<UserDetailDto> getCurrentUser()
        {

            var userId = _dbContext.getCurrentUserID();
            var user = await _dbContext.Users.Where(x => x.Id == userId).ProjectTo<UserDetailDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            return user;
        }
    }
}
