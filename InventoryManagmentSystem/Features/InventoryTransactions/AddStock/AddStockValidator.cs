using FluentValidation;

namespace InventoryManagmentSystem.Features.InventoryTransactions.AddStock;

public class AddStockValidator : AbstractValidator<AddStockRequest>
{
    public AddStockValidator()
    {
        RuleFor(element=>element.ProductId)
        .NotEmpty()
        .WithMessage("Product Id is not valid");
        RuleFor(element=>element.WarehouseId)
        .NotEmpty()
        .WithMessage("Warehouse Id is not valid");
        RuleFor(element=>element.Quantity)
        .NotEmpty()
        .WithMessage("Quantity is not valid");
    }
}