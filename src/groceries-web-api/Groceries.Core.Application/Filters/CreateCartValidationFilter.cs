using FluentValidation;
using Groceries.Core.Application.Models.DTOs.Requests;
using Groceries.Core.Domain.DomainExceptions;

namespace Groceries.Core.Application.Filters

{
    public class CreateCartValidationFilter(IValidator<CreateCartRequestDTO> createCartValidator) : IEndpointFilter
    {
        private readonly IValidator<CreateCartRequestDTO> _createCartValidator = createCartValidator;

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var indexOfCreateCartDTOArgument = 0;
            var createCartDTO = context.GetArgument<CreateCartRequestDTO>(indexOfCreateCartDTOArgument);
            var validationResult = _createCartValidator.Validate(createCartDTO);
            if (!validationResult.IsValid)
            {
                throw new DomainValidationException("");
            }
            return await next(context);
        }
    }
}