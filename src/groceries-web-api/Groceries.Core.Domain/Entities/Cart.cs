namespace Groceries.Core.Domain.Entities
{
    public class Cart : Entity
    {
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public List<GroceryItem> Items { get; private set; } = []; 
        public Reminder Reminder { get; private set; } = new();
    }
}