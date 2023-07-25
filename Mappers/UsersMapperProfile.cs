using tech_store.DbModels.Auth;
using tech_store.Dtos.User;

namespace tech_store.Mappers
{
    public class UsersMapperProfile : Profile
    {
        public UsersMapperProfile() 
        {
            CreateMap<User, UserGetDto>()
                .ForMember(dest => dest.roleId, opt => opt.MapFrom(src=>src.role_id));

            CreateMap<UserAddDto, User>()
                .ForMember(dest => dest.role_id, opt => opt.MapFrom(src => src.roleId)); ;
        }
    }
}
