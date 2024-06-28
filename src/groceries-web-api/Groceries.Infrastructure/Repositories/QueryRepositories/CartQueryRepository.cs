using Groceries.Core.Domain.Repositories;
using Groceries.Infrastructure.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Groceries.Infrastructure.Repositories.QueryRepositories 
{
    public class CartQueryRepository : IQueryRepository<Data.DataModels.Cart>
    {
        private readonly IGroceriesDbContext _groceriesDbContext;

        public CartQueryRepository(IGroceriesDbContext groceriesDbContext)
        {
            _groceriesDbContext = groceriesDbContext;
        }
        
        public async Task<IEnumerable<Data.DataModels.Cart>> GetAllAsync()
        {
            return await _groceriesDbContext.Carts.ToListAsync();
        }

        public async Task<Data.DataModels.Cart?> GetByIdAsync(Guid id)
        {
            return await _groceriesDbContext.Carts.FirstOrDefaultAsync(cart => cart.Id == id);
        }
    }
}