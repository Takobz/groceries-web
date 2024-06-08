using Groceries.Core.Domain.Repositories;

namespace Groceries.Infrastructure.Repositories.QueryRepositories 
{
    public class CartQueryRepository : IQueryRepository<Data.DataModels.Cart>
    {
        //IQueryable maybe ?
        public Task<IEnumerable<Data.DataModels.Cart>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Data.DataModels.Cart> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}