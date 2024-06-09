namespace Groceries.Core.Application.Models.DTOs.Response
{
    public class CartResponseDTO
    {
        public Guid CartId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public IEnumerable<CartItemResponseDTO> GroceryItems { get; init; } = [];
    }

    public class CartItemResponseDTO
    {
        public Guid CartItemId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public string Category { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public string ImageUrl { get; init; } = string.Empty;
    }
}