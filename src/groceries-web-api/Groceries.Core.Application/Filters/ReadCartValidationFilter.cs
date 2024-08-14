using Groceries.Core.Domain.DomainExceptions;

namespace Groceries.Core.Application.Filters 
{
    public class ReadCartValidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var indexOfCartId = 0;
            var cartId = context.GetArgument<Guid>(indexOfCartId);

            if (cartId == Guid.Empty)
            {
                //global exception handler will catch this exception and return a 400 status code
                throw new DomainValidationException("Cart Id is required");
            }

            return await next(context);
        }
    }
}