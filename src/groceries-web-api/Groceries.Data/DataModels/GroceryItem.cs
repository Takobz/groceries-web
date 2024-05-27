namespace Groceries.Data.DataModels
{
    /// <summary>
    /// Represents a grocery item in the database.
    /// To be used by Entity Framework Core to map the database table.
    /// </summary>
    public class GroceryItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
