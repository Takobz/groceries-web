using AutoMapper;
using Groceries.Core.Application.Models.DTOs.Requests;
using Groceries.Core.Application.Models.DTOs.Response;
using Groceries.Core.Application.Models.ServiceModels;

namespace Groceries.Core.Application.Helpers
{
    public class AppAutoMapperCartProfile : Profile
    {
        public AppAutoMapperCartProfile()
        {
            CreateMap<Domain.Entities.Cart, CartResponse>()
                .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Domain.Entities.GroceryItem, CartItemResponse>()
                .ForMember(dest => dest.CartItemId, opt => opt.MapFrom(src => src.Id));

            CreateMap<CartResponse, CreateCartResponseDTO>();
            CreateMap<CartResponse, CartResponseDTO>();
            CreateMap<CartItemResponse, CartItemResponseDTO>();
        }
    }
}