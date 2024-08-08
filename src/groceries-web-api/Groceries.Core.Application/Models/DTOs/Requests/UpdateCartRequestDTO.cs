namespace Groceries.Core.Application.Models.DTOs.Requests 
{
    public class UpdateCartRequestDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public IEnumerable<UpdateCartItemRequestDTO> GroceryItems { get; init; } = [];
    }

    public class UpdateCartItemRequestDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public string Category { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public string ImageUrl { get; init; } = string.Empty;
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}