using FluentValidation;
using InventoryManagmentSystem.Shared.Model;
namespace InventoryManagmentSystem.Features.ProductManagement.AddProduct;

public class AddProductValidator : AbstractValidator<AddProductRequest>
{
    public AddProductValidator()
    {
        RuleFor(element => element.Name)
        .NotNull()
        .WithMessage("Name Is Invalid");
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