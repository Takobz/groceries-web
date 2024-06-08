using Groceries.Core.Domain.DomainExceptions;

namespace Groceries.Core.Domain.Entities
{
    public class Cart : Entity, IAggregateRoot
    {
        public Cart(
            string name,
            string description,
            Reminder reminder,
            List<GroceryItem> items,
            DateTime createdAt,
            DateTime updatedAt)
        {
            Name = name;
            Description = description;
            Reminder = reminder ?? new();
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            _items = items ?? [];

            ValidateCartData();
        }

        private readonly List<GroceryItem> _items = [];

        public string Name { get; internal set; } = string.Empty;
        public string Description { get; internal set; } = string.Empty;
        public IReadOnlyCollection<GroceryItem> GroceryItems  => _items.AsReadOnly(); 
        public DateTime CreatedAt { get; internal set; }
        public DateTime UpdatedAt { get; internal set; }
        public Reminder Reminder { get; internal set; } = new();

        public Cart AddItemToCart(GroceryItem item)
        {
            ArgumentNullException.ThrowIfNull(item);
            _items.Add(item);
            return this;
        }

        private void ValidateCartData()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new DomainValidationException("Cart name cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(Description))
            {
                throw new DomainValidationException("Cart description cannot be null or empty.");
            }

            if (CreatedAt == default)
            {
                throw new DomainValidationException("Cart created date cannot be default.");
            }

            if (UpdatedAt == default)
            {
                throw new DomainValidationException("Cart updated date cannot be default.");
            }

            //Would be nice to fire an event for these exceptions
        }

        //TODO: Fire an event when an item is added to the cart
    }
}
