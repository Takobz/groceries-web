namespace Groceries.Core.Application.Models.DTOs.Requests
{
    public class AddItemsToCartRequestDTO
    {
        public Guid CartId { get; init; }
        public IEnumerable<AddCartItemRequestDTO> GroceryItems { get; init; } = [];
    }

    public class AddCartItemRequestDTO 
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public string Category { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public string ImageUrl { get; init; } = string.Empty;
    }
}