
using FluentValidation;
using Groceries.Core.Application.Models.DTOs.Requests;
using Groceries.Core.Domain.DomainExceptions;

namespace Groceries.Core.Application.Filters
{
    public class UpdateCartValidatorFilter : IEndpointFilter
    {
        private readonly IValidator<UpdateCartRequestDTO> _updateCartvalidator;

        UpdateCartValidatorFilter(IValidator<UpdateCartRequestDTO> updateCartvalidator)
        {
            _updateCartvalidator = updateCartvalidator;
        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var indexOfUpdateCartDTOArgument = 1;
            var updateCartDTO = context.GetArgument<UpdateCartRequestDTO>(indexOfUpdateCartDTOArgument);
            var validationResult = _updateCartvalidator.Validate(updateCartDTO);
            if (!validationResult.IsValid)
            {
                throw new DomainValidationException("");
            }
            return await next(context);
        }
    }
}