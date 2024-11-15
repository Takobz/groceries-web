namespace Groceries.Core.Application.Models.DTOs.Response
{
    //TODO: Use this for cart details update instead of returning the whole cart
    public class UpdateCartDetailsResponseDTO
    {
        public Guid CartId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
    }
}