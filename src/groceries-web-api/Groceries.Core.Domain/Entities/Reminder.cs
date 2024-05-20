namespace Groceries.Core.Domain.Entities
{
    public class Reminder : Entity
    {
        public string Name { get; internal set; } = string.Empty;
        public string Description { get; internal set; } = string.Empty;
        public DateTime ReminderDate { get; internal set; }
        public bool IsCompleted { get; internal set; }
    }
}