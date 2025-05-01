using FluentValidation;

namespace InventoryManagmentSystem.Features.InventoryTransactions.AddStock;

public class AddStockValidator : AbstractValidator<AddStockRequest>
{
    public AddStockValidator()
    {
        RuleFor(element=>element.ProductId).NotEmpty().WithMessage("");
        RuleFor(element=>element.WarehouseId).NotEmpty().WithMessage("");
        RuleFor(element=>element.Quantity).NotEmpty().WithMessage("");
    }
}