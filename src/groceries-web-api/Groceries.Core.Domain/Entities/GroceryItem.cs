namespace Groceries.Core.Domain.Entities
{
    public class GroceryItem : Entity
    {
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string Category { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public string ImageUrl { get; private set; } = string.Empty;
    }
}