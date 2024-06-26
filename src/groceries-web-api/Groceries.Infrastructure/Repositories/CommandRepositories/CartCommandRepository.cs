//Command classes should strictly use Domain Entities and Value Objects for making changes to the database.
//But return DataModels to the Application layer.
using Groceries.Infrastructure.Repositories.DbContexts;
using AutoMapper;

namespace Groceries.Infrastructure.Repositories.CommandRepositories
{
    public interface ICartCommandRepository
    {
        Task<Data.DataModels.Cart> CreateCartAsync(Core.Domain.Entities.Cart cart);
    }

    public class CartCommandRepository : ICartCommandRepository
    {
        private readonly IGroceriesDbContext _groceriesDbContext;
        private readonly IMapper _mapper;

        public CartCommandRepository(IGroceriesDbContext groceriesDbContext, IMapper mapper)
        {
            _groceriesDbContext = groceriesDbContext;
            _mapper = mapper;
        }

        public async Task<Data.DataModels.Cart> CreateCartAsync(Core.Domain.Entities.Cart cart)
        {
            var cartDataModel = _mapper.Map<Data.DataModels.Cart>(cart);
            _groceriesDbContext.Carts.Add(cartDataModel);
            await _groceriesDbContext.SaveChangesAsync();
            return cartDataModel;
        }
    }
}