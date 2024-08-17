
using FluentValidation;
using Groceries.Core.Application.Models.DTOs.Requests;
using Groceries.Core.Application.Validators;
using Groceries.Core.Domain.DomainExceptions;

namespace Groceries.Core.Application.Filters
{
    public class AddItemsToCartValidationFilter(IValidator<AddItemsToCartRequestDTO> validator) : IEndpointFilter
    {
        private readonly IValidator<AddItemsToCartRequestDTO> _validator = validator;

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            int indexOfCartId = 0;
            var cartId = context.GetArgument<Guid>(indexOfCartId);
            if (cartId == Guid.Empty)
            {
                throw new DomainValidationException("Cart Id is required");
            }

            int indexOfCartItems = 1;
            var cartItems = context.GetArgument<AddItemsToCartRequestDTO>(indexOfCartItems);
            var validationResult = _validator.Validate(cartItems);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(x => x.ErrorMessage);
                throw new DomainValidationException(string.Join("; ", errors));
            }

            return await next(context);
        }
    }
}