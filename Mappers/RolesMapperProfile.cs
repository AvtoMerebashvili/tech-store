using tech_store.DbModels.Auth;
using tech_store.Dtos.Roles;
using tech_store.Dtos.User;

namespace tech_store.Mappers
{
    public class RolesMapperProfile : Profile
    {
        public RolesMapperProfile() 
        {
            CreateMap<Role, RolesGetDto>();
            CreateMap<RolesAddDto, Role>();
        }
    }
}
