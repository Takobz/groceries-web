using Groceries.Core.Domain.Entities;

namespace Groceries.Core.Domain.Repositories
{
    /// <summary>
    /// Interface for command operations on the application's database.
    /// </summary>
    /// <typeparam name="T">Aggregate root will be converted into a data model that the database understands</typeparam>
    public interface ICommandRepository<T> where T : IAggregateRoot
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
