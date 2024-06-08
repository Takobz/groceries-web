using Microsoft.EntityFrameworkCore;

namespace Groceries.Infrastructure.Repositories.DbContexts
{
    public interface IGroceriesDbContext
    {
        DbSet<Data.DataModels.Cart> Carts { get; set; }
        DbSet<Data.DataModels.GroceryItem> CartItems { get; set; }
        DbSet<Data.DataModels.Reminder> Reminders { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class GroceriesDbContext(DbContextOptions<GroceriesDbContext> options) : DbContext(options), IGroceriesDbContext
    {
        public DbSet<Data.DataModels.Cart> Carts { get; set; }
        public DbSet<Data.DataModels.GroceryItem> CartItems { get; set; }
        public DbSet<Data.DataModels.Reminder> Reminders { get; set; }
    }
}