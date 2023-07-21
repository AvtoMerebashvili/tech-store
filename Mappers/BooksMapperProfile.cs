using tech_store.DbModels.Products;

namespace tech_store.Mappers
{
    public class BooksMapperProfile : Profile
    {
        public BooksMapperProfile() {
            CreateMap<BookCreateDto, Order>()
                .ForMember(dest => dest.product_id, act => act.MapFrom(src => src.productId))
                .ForMember(dest => dest.is_book, act => act.MapFrom(src => src.isBook));

            CreateMap<Order, BookGetDto>()
                .ForMember(dest => dest.productId, act => act.MapFrom(src => src.product_id))
                .ForMember(dest => dest.createDate, act => act.MapFrom(src => src.create_date))
                .ForMember(dest => dest.expirationDate, act => act.MapFrom(src => src.expiration_date));

        }
    }
}
