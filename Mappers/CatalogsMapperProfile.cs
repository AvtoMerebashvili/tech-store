using tech_store.DbModels.Catalogs;

namespace tech_store.Mappers
{
    public class CatalogsMapperProfile : Profile
    {
        public CatalogsMapperProfile()
        {
            CreateMap<Brand, BrandGetDto>();
            CreateMap<BrandAddDto, Brand>();
            CreateMap<City, CityGetDto>();
            CreateMap<CityAddDto, City>();
            CreateMap<Country, CountryGetDto>();
            CreateMap<CountryAddDto, Country>();
            CreateMap<Model, ModelGetDto>();
            CreateMap<ModelAddDto, Model>();
            CreateMap<ProductType, ProductTypeGetDto>();
            CreateMap<ProductTypeAddDto, ProductType>();
        }
    }
}
