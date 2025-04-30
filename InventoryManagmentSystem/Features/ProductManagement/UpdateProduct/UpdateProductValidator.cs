
using FluentValidation;
namespace InventoryManagmentSystem.Features.ProductManagement.UpdateProduct;

public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductValidator()
    {
        RuleFor(element => element.UpdatedProduct).NotNull();
        RuleFor(element => element.OldProductID).NotNull();
        RuleFor(element => element.UpdatedProduct.Name).NotEmpty().NotNull();
        RuleFor(element => element.UpdatedProduct.LowStockThreshold).NotNull();
        RuleFor(element => element.UpdatedProduct.Price).NotNull();
        RuleFor(element => element.UpdatedProduct.Description).NotEmpty();
    }
}