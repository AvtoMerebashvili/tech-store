using tech_store.DbModels.Auth;
using tech_store.Dtos.User;

namespace tech_store.Mappers
{
    public class UsersMapperProfile : Profile
    {
        public UsersMapperProfile() 
        {
            CreateMap<User, UserGetDto>();
            CreateMap<UserAddDto, User>();
        }
    }
}
