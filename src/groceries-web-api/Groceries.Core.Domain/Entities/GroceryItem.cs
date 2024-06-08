using Groceries.Core.Domain.DomainExceptions;

namespace Groceries.Core.Domain.Entities
{
    public class GroceryItem : Entity
    {
        public string Name { get; internal set; } = string.Empty;
        public string Description { get; internal set; } = string.Empty;
        public string Category { get; internal set; } = string.Empty;
        public decimal Price { get; internal set; }
        public string ImageUrl { get; internal set; } = string.Empty;
        public DateTime CreatedAt { get; internal set; }
        public DateTime UpdatedAt { get; internal set; }

        public GroceryItem(
            string name,
            string description,
            string category,
            decimal price,
            string imageUrl,
            DateTime createdAt,
            DateTime updatedAt)
        {
            if (string.IsNullOrEmpty(name)) throw new DomainValidationException("Grocery item name cannot be null or empty.");

            if (createdAt == default) throw new DomainValidationException("Grocery item created date cannot be default.");

            if (updatedAt == default) throw new DomainValidationException("Grocery item updated date cannot be default.");

            Name = name;
            Description = description;
            Category = category;
            Price = price;
            ImageUrl = imageUrl;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}