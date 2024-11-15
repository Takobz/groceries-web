using FluentValidation;
using Groceries.Core.Application.Models.DTOs.Requests;

namespace Groceries.Core.Application.Validators
{
    public class UpdateCartDetailsValidator : AbstractValidator<UpdateCartDetailsRequestDTO>
    {
        public UpdateCartDetailsValidator()
        {
            RuleFor(x => x)
                .Must(x => !string.IsNullOrEmpty(x.Name) || !string.IsNullOrEmpty(x.Description))
                .WithMessage("Either Name or Description must be provided.");

            RuleFor(x => x.Name).MaximumLength(100);
            RuleFor(x => x.Description).MaximumLength(500);
        }
    }
}