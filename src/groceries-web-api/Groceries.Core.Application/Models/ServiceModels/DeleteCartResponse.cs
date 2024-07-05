using Groceries.Core.Domain.Entities;

namespace Groceries.Core.Application.Models.ServiceModels 
{
    public class DeleteCartResponse 
    {
        public DeleteCartResponse(bool isDeleted, bool isCartFound)
        {
            IsDeleted = isDeleted;
            IsCartFound = isCartFound;
        }

        public bool IsDeleted { get; init; }
        public bool IsCartFound { get; init; }
    }
}