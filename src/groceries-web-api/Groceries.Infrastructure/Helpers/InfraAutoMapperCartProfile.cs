using AutoMapper;

namespace Groceries.Infrastructure.Helpers
{
    public class InfraAutoMapperCartProfile : Profile
    {
        public InfraAutoMapperCartProfile()
        {
            #region Cart Domain Model to Database Model
            CreateMap<Core.Domain.Entities.Cart, Data.DataModels.Cart>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.GroceryItems, opt => opt.MapFrom(src => src.GroceryItems)); 

            CreateMap<Core.Domain.Entities.GroceryItem, Data.DataModels.GroceryItem>();
            #endregion

            #region Database Model to Cart Domain Model
            #endregion
        }
    }
}
