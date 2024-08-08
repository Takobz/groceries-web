namespace Groceries.Core.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; internal set; }
    }
}