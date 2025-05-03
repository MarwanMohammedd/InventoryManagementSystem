using FluentValidation;
using InventoryManagmentSystem.Features.InventoryTransactions.Commands.AddStock;

namespace InventoryManagmentSystem.Features.InventoryTransactions.Validators;

public class AddStockValidator : AbstractValidator<AddStockCommandRequest>
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