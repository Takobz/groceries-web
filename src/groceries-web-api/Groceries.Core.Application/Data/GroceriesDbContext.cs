using Groceries.Infrastructure.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Groceries.Core.Application.Data
{
    #pragma warning disable CS8618 
    public class GroceriesDbContext : DbContext, IGroceriesDbContext
    {
        public GroceriesDbContext(DbContextOptions<GroceriesDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Groceries.Data.DataModels.Cart> Carts { get; set; }
        public DbSet<Groceries.Data.DataModels.GroceryItem> CartItems { get; set; }
        public DbSet<Groceries.Data.DataModels.Reminder> Reminders { get; set; }
    }
}