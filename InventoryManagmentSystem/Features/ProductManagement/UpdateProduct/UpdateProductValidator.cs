
using FluentValidation;
namespace InventoryManagmentSystem.Features.ProductManagement.UpdateProduct;

public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
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