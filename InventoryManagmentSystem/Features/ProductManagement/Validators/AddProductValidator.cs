using FluentValidation;
using InventoryManagmentSystem.Features.ProductManagement.Commands;
namespace InventoryManagmentSystem.Features.ProductManagement.Validators;

public class AddProductValidator : AbstractValidator<AddProductCommandRequest>
{
    public AddProductValidator()
    {
        RuleFor(element => element.Name)
        .NotNull()
        .WithMessage("Name Is Invalid");
        RuleFor(element => element.CategoryId)
        .NotEmpty()
        .WithMessage("Category Id Is Invalid");
        RuleFor(element => element.Price)
        .NotNull()
        .WithMessage("Price Is Invalid");
        RuleFor(element => element.LowStockThreshold)
        .NotNull()
        .WithMessage("LowStockThreshold is Invalid");
        RuleFor(element => element.Description)
        .NotEmpty()
        .NotNull()
        .WithMessage("Description is Invalid");
    }
}