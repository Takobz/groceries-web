using Groceries.Core.Domain.DomainExceptions;

namespace Groceries.Core.Application.Helpers
{
    public static class DataToDomainMapper 
    {
        public static Domain.Entities.GroceryItem ToGroceryItem(this Groceries.Data.DataModels.GroceryItem item)
        {
            if (item == null)
            {
                throw new DomainValidationException("Can't convert null grocery item to grocery item entity.");
            }

            return new Domain.Entities.GroceryItem(
                item.Name,
                item.Description,
                item.Category,
                item.Price,
                item.ImageUrl,
                item.CreatedAt,
                item.UpdatedAt
            );
        }
    }
}