
using Groceries.Core.Domain.DomainExceptions;

namespace Groceries.Core.Application.Filters
{
    public class RemoveItemFromCartValidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var indexOfCartId = 0;
            var indexOfCartItemId = 1;
            var cartId = context.GetArgument<Guid>(indexOfCartId);
            var cartItemId = context.GetArgument<Guid>(indexOfCartItemId);

            if (cartId == Guid.Empty)
            {
                throw new DomainValidationException("Cart Id is required");
            }

            if (cartItemId == Guid.Empty)
            {
                throw new DomainValidationException("Cart Item Id is required");
            }

            return await next(context);
        }
    }
}