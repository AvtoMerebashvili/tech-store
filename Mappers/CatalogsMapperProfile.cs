using tech_store.DbModels.Catalogs;

namespace tech_store.Mappers
{
    public class CatalogsMapperProfile : Profile
    {
        public CatalogsMapperProfile()
        {
            CreateMap<Brand, BrandGetDto>();
            CreateMap<BrandAddDto, Brand>();
            CreateMap<City, CityGetDto>()
                .ForMember(dest => dest.countryId, act => act.MapFrom(src => src.country_id));
            CreateMap<CityAddDto, City>()
                .ForMember(dest => dest.country_id, act => act.MapFrom(src => src.countryId)); ;
            CreateMap<Country, CountryGetDto>();
            CreateMap<CountryAddDto, Country>();
            CreateMap<Model, ModelGetDto>()
                .ForMember(dest => dest.brandId, act => act.MapFrom(src => src.brand_id));
            CreateMap<ModelAddDto, Model>()
                .ForMember(dest => dest.brand_id, act => act.MapFrom(src => src.brandId));
            CreateMap<ProductType, ProductTypeGetDto>();
            CreateMap<ProductTypeAddDto, ProductType>();
        }
    }
}
