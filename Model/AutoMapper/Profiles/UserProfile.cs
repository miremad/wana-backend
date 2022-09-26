using AutoMapper;
using Model.Model;
using Model.ViewModel;


namespace Model.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserDetailDto>();
            CreateMap<CreateUserDto, ApplicationUser>()
                .ForMember(d => d.UserName, src => src.MapFrom(p => p.PhoneNumber));
        }
        
    }
}
