using FluentValidation;
using InventoryManagmentSystem.Shared.Model;
namespace InventoryManagmentSystem.Features.ProductManagement.AddProduct;

public class AddProductValidator : AbstractValidator<AddProductRequest>
{
    public AddProductValidator()
    {
        RuleFor(element=>element.NewProduct).NotNull();
        RuleFor(element=>element.NewProduct.Name).NotNull();
        RuleFor(element=>element.NewProduct.Price).NotNull();
        RuleFor(element=>element.NewProduct.LowStockThreshold).NotNull();
        RuleFor(element=>element.NewProduct.Description).NotEmpty().NotNull();
    }
}