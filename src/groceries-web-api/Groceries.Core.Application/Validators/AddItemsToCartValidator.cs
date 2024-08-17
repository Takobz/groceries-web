using FluentValidation;
using Groceries.Core.Application.Models.DTOs.Requests;

namespace Groceries.Core.Application.Validators
{
    public class AddItemsToCartValidator : AbstractValidator<AddItemsToCartRequestDTO>
    {
        public AddItemsToCartValidator()
        {
            RuleFor(x => x.CartId).NotEmpty();
            RuleFor(x => x.GroceryItems).NotEmpty();
            RuleForEach(x => x.GroceryItems).SetValidator(new AddCartItemValidator());
        }
    }

    public class AddCartItemValidator : AbstractValidator<AddCartItemRequestDTO>
    {
        public AddCartItemValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
            RuleFor(x => x.Category).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
        }
    }
}