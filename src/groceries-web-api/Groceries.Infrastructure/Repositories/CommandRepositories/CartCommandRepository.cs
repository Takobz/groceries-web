//Command classes should strictly use Domain Entities and Value Objects for making changes to the database.
//But return DataModels to the Application layer.
using Groceries.Infrastructure.Repositories.DbContexts;
using AutoMapper;

namespace Groceries.Infrastructure.Repositories.CommandRepositories
{
    public interface ICartCommandRepository
    {
        Task<Data.DataModels.Cart> CreateCartAsync(Core.Domain.Entities.Cart cart);
        Task<Data.DataModels.Cart> UpdateCartAsync(Core.Domain.Entities.Cart cart);
        Task DeleteByIdAsync(Data.DataModels.Cart cart);
        Task DeleteCartGroceryItemAsync(Data.DataModels.GroceryItem cartGroceryItem);
    }

    public class CartCommandRepository(IGroceriesDbContext groceriesDbContext, IMapper mapper) : ICartCommandRepository
    {
        private readonly IGroceriesDbContext _groceriesDbContext = groceriesDbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<Data.DataModels.Cart> CreateCartAsync(Core.Domain.Entities.Cart cart)
        {
            var cartDataModel = _mapper.Map<Data.DataModels.Cart>(cart);
            _groceriesDbContext.Carts.Add(cartDataModel);
            await _groceriesDbContext.SaveChangesAsync();
            return cartDataModel;
        }

        public async Task<Data.DataModels.Cart> UpdateCartAsync(Core.Domain.Entities.Cart cart)
        {
            var cartDataModel = _mapper.Map<Data.DataModels.Cart>(cart);
            _groceriesDbContext.Carts.Update(cartDataModel);
            await _groceriesDbContext.SaveChangesAsync();
            return cartDataModel;
        }

        public async Task DeleteByIdAsync(Data.DataModels.Cart cart)
        {
            _groceriesDbContext.Carts.Remove(cart);
            await _groceriesDbContext.SaveChangesAsync();
        }

        public async Task DeleteCartGroceryItemAsync(Data.DataModels.GroceryItem cartGroceryItem)
        {
            _groceriesDbContext.CartItems.Remove(cartGroceryItem);
            await _groceriesDbContext.SaveChangesAsync();
        }
    }
}