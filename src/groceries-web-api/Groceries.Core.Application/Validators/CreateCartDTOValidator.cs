using FluentValidation;
using Groceries.Core.Application.Models.DTOs.Requests;

namespace Groceries.Core.Application.Validators
{
    public class CreateCartDTOValidator : AbstractValidator<CreateCartRequestDTO>
    {
        public CreateCartDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
            RuleForEach(x => x.GroceryItems).SetValidator(new CreateCartItemDTOValidator());
        }
    }

    public class CreateCartItemDTOValidator : AbstractValidator<CreateCartItemRequestDTO>
    {
        public CreateCartItemDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
            RuleFor(x => x.Category).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
            RuleFor(x => x.CreatedAt).NotEmpty();
            RuleFor(x => x.UpdatedAt).NotEmpty();
        }
    }
}