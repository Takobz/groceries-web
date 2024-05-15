namespace Groceries.Core.Domain.Entities
{
    public class Reminder : Entity
    {
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public DateTime ReminderDate { get; private set; }
        public bool IsCompleted { get; private set; }
    }
}