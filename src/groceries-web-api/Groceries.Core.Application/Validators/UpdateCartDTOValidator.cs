using FluentValidation;
using Groceries.Core.Application.Models.DTOs.Requests;

namespace Groceries.Core.Application.Validators
{
    public class UpdateCartDTOValidator : AbstractValidator<UpdateCartRequestDTO>
    {
        public UpdateCartDTOValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
            RuleForEach(x => x.GroceryItems).SetValidator(new UpdateCartItemDTOValidator());
        }
    }

    public class UpdateCartItemDTOValidator : AbstractValidator<UpdateCartItemRequestDTO>
    {
        public UpdateCartItemDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
            RuleFor(x => x.Category).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
        }
    }
}