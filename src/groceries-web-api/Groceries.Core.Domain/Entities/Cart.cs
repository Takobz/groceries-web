namespace Groceries.Core.Domain.Entities
{
    public class Cart : Entity, IAggregateRoot
    {
        private readonly List<GroceryItem> _items = [];

        public string Name { get; internal set; } = string.Empty;
        public string Description { get; internal set; } = string.Empty;
        public IReadOnlyCollection<GroceryItem> Items  => _items.AsReadOnly(); 
        public Reminder Reminder { get; internal set; } = new();

        public Cart AddItemToCart(GroceryItem item)
        {
            ArgumentNullException.ThrowIfNull(item);
            _items.Add(item);
            return this;
        }

        //TODO: Fire an event when an item is added to the cart
    }
}
