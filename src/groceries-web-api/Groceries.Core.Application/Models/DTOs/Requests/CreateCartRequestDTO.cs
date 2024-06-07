namespace Groceries.Core.Application.Models.DTOs.Requests
{
    public class CreateCartRequestDTO
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public IEnumerable<CreateCartItemRequestDTO> GroceryItems { get; init; } = []; 
    }

    public class CreateCartItemRequestDTO
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public string Category { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public string ImageUrl { get; init; } = string.Empty;
    }
}