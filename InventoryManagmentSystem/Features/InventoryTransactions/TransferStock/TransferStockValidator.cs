using FluentValidation;

namespace InventoryManagmentSystem.Features.InventoryTransactions.TransferStock;

public class TransferStockValidator : AbstractValidator<TransferStockRequest>
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