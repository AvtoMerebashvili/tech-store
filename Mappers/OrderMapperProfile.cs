using tech_store.DbModels.Products;
using tech_store.Dtos.OrderItems;

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


            CreateMap<Order, OrderGetDto>()
                .ForMember(dest => dest.productId, act => act.MapFrom(src => src.product_id))
                .ForMember(dest => dest.createDate, act => act.MapFrom(src => src.create_date))
                .ForMember(dest => dest.endDate, act => act.MapFrom(src => src.end_date))
                .ForMember(dest => dest.orderItemsId, act => act.MapFrom(src => src.order_items_id))
                .ForMember(dest => dest.passInBranch, act => act.MapFrom(src => src.pass_in_branch))
                .ForMember(dest => dest.deliveryAddressId, act => act.MapFrom(src => src.delivery_address_id));

            CreateMap<OrderItemsCreateDto, OrderItem>()
                .ForMember(dest => dest.is_active, act => act.MapFrom(src => src.isActive));

            CreateMap<OrderItem, OrderItemsGetDto>();

        }
    }
}
