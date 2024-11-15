
using FluentValidation;
using Groceries.Core.Application.Models.DTOs.Requests;
using Groceries.Core.Domain.DomainExceptions;

namespace Groceries.Core.Application.Filters
{
    public class UpdateCartDetailsValidationFilter(IValidator<UpdateCartDetailsRequestDTO> updateCartDetailsValidator) : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var indexOfCartId = 0;
            var cartId = context.GetArgument<Guid>(indexOfCartId);
            if (cartId == Guid.Empty)
            {
                throw new DomainValidationException("Cart Id is required");
            }

            var indexOfUpdateCartDTOArgument = 1;
            var updateCartDTO = context.GetArgument<UpdateCartDetailsRequestDTO>(indexOfUpdateCartDTOArgument);
            var validationResult = updateCartDetailsValidator.Validate(updateCartDTO);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(x => x.ErrorMessage);
                throw new DomainValidationException(string.Join("; ", errors));
            }

            return await next(context);
        }
    }
}