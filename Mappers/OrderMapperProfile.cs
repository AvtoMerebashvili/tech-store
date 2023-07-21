using tech_store.DbModels.Products;

namespace tech_store.Mappers
{
    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile() {
            CreateMap<OrderCreateDto, Order>()
                .ForMember(dest => dest.is_book, act => act.MapFrom(src => src.isBook))
                .ForMember(dest => dest.product_id, act => act.MapFrom(src => src.productId))
                .ForMember(dest => dest.order_items_id, act => act.MapFrom(src => src.orderItemsId))
                .ForMember(dest => dest.pass_in_branch, act => act.MapFrom(src => src.passInBranch))
                .ForMember(dest => dest.delivery_address_id, act => act.MapFrom(src => src.deliveryAddressId));

            CreateMap<Order, OrderItemsGetDto>();

            CreateMap<OrderItemsCreateDto, OrderItem>();

            CreateMap<OrderItem, OrderItemsGetDto>();

        }
    }
}
