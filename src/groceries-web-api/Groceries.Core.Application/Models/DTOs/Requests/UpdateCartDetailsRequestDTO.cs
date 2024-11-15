namespace Groceries.Core.Application.Models.DTOs.Requests
{
    public class UpdateCartDetailsRequestDTO
    {        
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
    }
}