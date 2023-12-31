﻿using tech_store.DbModels.Products;

namespace tech_store.Mappers
{
    public class ProductsMapperProfile : Profile
    {
        public ProductsMapperProfile() {
            CreateMap<ProductAddDto, Product>()
                .ForMember(dest => dest.product_type_id, act => act.MapFrom(src => src.productTypeId))
                .ForMember(dest => dest.on_sale, act => act.MapFrom(src => src.onSale))
                .ForMember(dest => dest.selling_cost, act => act.MapFrom(src => src.sellingCost))
                .ForMember(dest => dest.buying_cost, act => act.MapFrom(src => src.buyingCost))
                .ForMember(dest => dest.initial_quantity, act => act.MapFrom(src => src.initialQuantity))
                .ForMember(dest => dest.model_id, act => act.MapFrom(src => src.modelId));

            CreateMap<ProductUpdateDto, Product>()
                .ForMember(dest => dest.product_type_id, act => act.MapFrom(src => src.productTypeId))
                .ForMember(dest => dest.on_sale, act => act.MapFrom(src => src.onSale))
                .ForMember(dest => dest.selling_cost, act => act.MapFrom(src => src.sellingCost))
                .ForMember(dest => dest.buying_cost, act => act.MapFrom(src => src.buyingCost))
                .ForMember(dest => dest.initial_quantity, act => act.MapFrom(src => src.initialQuantity))
                .ForMember(dest => dest.model_id, act => act.MapFrom(src => src.modelId));

            CreateMap<Product, ProductsGetDto>()
                .ForMember(dest => dest.onSale, act => act.MapFrom(src => src.on_sale))
                .ForMember(dest => dest.sellingCost, act => act.MapFrom(src => src.selling_cost))
                .ForMember(dest => dest.creatorId, act => act.MapFrom(src => src.creator_id))
                .ForMember(dest => dest.productTypeId, act => act.MapFrom(src => src.product_type_id))
                .ForMember(dest => dest.modelId, act => act.MapFrom(src => src.model_id))
                ;

        }
    }
}
