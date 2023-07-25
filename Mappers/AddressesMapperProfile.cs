using tech_store.DbModels.Auth;
using tech_store.Dtos.Address;

namespace tech_store.Mappers
{
    public class AddressesMapperProfile : Profile
    {
        public AddressesMapperProfile() 
        {
            CreateMap<AddressAddDto, Address>()
                .ForMember(dest=>dest.postal_code, opt => opt.MapFrom(src => src.postalCode))
                .ForMember(dest => dest.target_name, opt => opt.MapFrom(src => src.targetName))
                .ForMember(dest => dest.target_surname, opt => opt.MapFrom(src => src.targetSurname));

            CreateMap<Address, AddressGetDto>()
                .ForMember(dest => dest.postalCode, opt => opt.MapFrom(src => src.postal_code))
                .ForMember(dest => dest.targetName, opt => opt.MapFrom(src => src.target_name))
                .ForMember(dest => dest.targetSurname, opt => opt.MapFrom(src => src.target_surname));

        }
    }
}
