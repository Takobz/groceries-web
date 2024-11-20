namespace Groceries.Core.Application.Models.ServiceModels 
{
    public class DeleteCartItemResponse(bool isCartItemDeleted, bool isCartFound)
    {
        public bool IsCartItemDeleted { get; init; } = isCartItemDeleted;
        public bool IsCartFound { get; init; } = isCartFound;
        public bool IsCartItemFound { get; } = isCartItemDeleted && isCartFound;
    }
}