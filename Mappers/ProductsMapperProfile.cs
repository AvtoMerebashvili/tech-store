using tech_store.DbModels.Products;

namespace tech_store.Mappers
{
    public class ProductsMapperProfile : Profile
    {
        public ProductsMapperProfile() {
            CreateMap<ProductAddDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductsGetDto>();
        }
    }
}
