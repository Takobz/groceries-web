using AutoMapper;
using Groceries.Core.Application.Models.DTOs.Response;
using Groceries.Core.Application.Models.ServiceModels;

namespace Groceries.Core.Application.Helpers
{
    public class AppAutoMapperCartProfile : Profile
    {
        public AppAutoMapperCartProfile()
        {
            #region Domain Models -> Application Layer Models
            CreateMap<Domain.Entities.Cart, CartResponse>()
                .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Domain.Entities.GroceryItem, CartItemResponse>()
                .ForMember(dest => dest.CartItemId, opt => opt.MapFrom(src => src.Id));
            #endregion

            #region Application Layer Models
            CreateMap<CartResponse, CreateCartResponseDTO>();
            CreateMap<CartResponse, CartResponseDTO>();
            CreateMap<CartItemResponse, CartItemResponseDTO>();
            #endregion

            #region Database Models -> App Layer
            CreateMap<Groceries.Data.DataModels.Cart, CartResponse>()
                .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Groceries.Data.DataModels.GroceryItem, CartItemResponse>()
                .ForMember(dest => dest.CartItemId, opt => opt.MapFrom(src => src.Id));
            #endregion

            #region Database Models -> DTOs
            CreateMap<Groceries.Data.DataModels.Cart, CreateCartResponseDTO>();
            CreateMap<Groceries.Data.DataModels.Cart, CartResponseDTO>();
            CreateMap<Groceries.Data.DataModels.GroceryItem, CartItemResponseDTO>();
            #endregion
        }
    }
}