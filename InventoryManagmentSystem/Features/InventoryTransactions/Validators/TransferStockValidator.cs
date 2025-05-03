using FluentValidation;
using InventoryManagmentSystem.Features.InventoryTransactions.Commands.TransferStock;

namespace InventoryManagmentSystem.Features.InventoryTransactions.Validators;

public class TransferStockValidator : AbstractValidator<TransferStockCommandRequest>
{
    public TransferStockValidator()
    {
        RuleFor(element=>element.FromWareHouseId)
        .NotEmpty()
        .WithMessage("Invalid From WareHouse Id");
        RuleFor(element=>element.ToWareHouseId)
        .NotEmpty()
        .WithMessage("Invalid To WareHouse Id");
        RuleFor(element=>element.ProductId)
        .NotEmpty()
        .WithMessage("Invalid Product Id");
        RuleFor(element=>element.Quantity)
        .NotEmpty()
        .WithMessage("Invalid Quantity");
    }
}