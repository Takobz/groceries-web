namespace Groceries.Core.Domain.Repositories
{
    /// <summary>
    /// Interface for querying the application's database.
    /// </summary>
    /// <typeparam name="T">Class that represent a Data Model that represent the database columns</typeparam>
    public interface IQueryRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
