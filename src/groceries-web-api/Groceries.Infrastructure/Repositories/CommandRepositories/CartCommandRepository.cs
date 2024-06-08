//Command classes should strictly use Domain Entities and Value Objects for making changes to the database.
//But return DataModels to the Application layer.
using AutoMapper;
using Groceries.Core.Domain.Entities;
using Groceries.Infrastructure.Repositories.DbContexts;

namespace Groceries.Infrastructure.Repositories.CommandRepositories
{
    public interface ICartCommandRepository
    {
        Task<Data.DataModels.Cart> CreateCartAsync(Cart cart);
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

        public async Task<Data.DataModels.Cart> CreateCartAsync(Cart cart)
        {
            var cartDataModel = _mapper.Map<Data.DataModels.Cart>(cart);
            _groceriesDbContext.Carts.Add(cartDataModel);
            await _groceriesDbContext.SaveChangesAsync();
            return cartDataModel;
        }
    }
}