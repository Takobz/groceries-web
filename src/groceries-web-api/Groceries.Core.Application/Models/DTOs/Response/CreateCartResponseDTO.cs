namespace Groceries.Core.Application.Models.DTOs.Response
{
    public class CreateCartResponseDTO
    {
        public Guid CartId { get; init; } = Guid.NewGuid();
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public IEnumerable<CreateCartItemResponseDTO> GroceryItems { get; init; } = [];
    }

    public class CreateCartItemResponseDTO
    {
        public Guid CartItemId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public string Category { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public string ImageUrl { get; init; } = string.Empty;
    }
}