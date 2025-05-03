
using FluentValidation;
using InventoryManagmentSystem.Features.ProductManagement.Commands;
namespace InventoryManagmentSystem.Features.ProductManagement.Validators;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommandRequest>
{
    public UpdateProductValidator()
    {
        RuleFor(element => element.UpdatedProduct)
        .NotNull().WithMessage("Invalid Updated Product Data");
        RuleFor(element => element.OldProductID)
        .NotNull()
        .WithMessage("Invalid Old Product ID");
        RuleFor(element => element.UpdatedProduct.Name)
        .NotEmpty()
        .NotNull()
        .WithMessage("Invalid Updated Product Name");
        RuleFor(element => element.UpdatedProduct.LowStockThreshold)
        .NotNull()
        .WithMessage("Invalid Updated Product LowStockThreshold");
        RuleFor(element => element.UpdatedProduct.Price)
        .NotNull()
        .WithMessage("Invalid Updated Product Price");
        RuleFor(element => element.UpdatedProduct.Description)
        .NotEmpty()
        .WithMessage("Invalid Updated Product Description");
    }
}