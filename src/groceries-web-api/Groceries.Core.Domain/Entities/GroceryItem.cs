namespace Groceries.Core.Domain.Entities
{
    public class GroceryItem : Entity
    {
        public string Name { get; internal set; } = string.Empty;
        public string Description { get; internal set; } = string.Empty;
        public string Category { get; internal set; } = string.Empty;
        public decimal Price { get; internal set; }
        public string ImageUrl { get; internal set; } = string.Empty;

        public static GroceryItem CreateNewItem(
            string name,
            string description,
            string category,
            decimal price,
            string imageUrl)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            return new GroceryItem
            {
                Name = name,
                Description = description,
                Category = category,
                Price = price,
                ImageUrl = imageUrl
            };
        }
    }
}