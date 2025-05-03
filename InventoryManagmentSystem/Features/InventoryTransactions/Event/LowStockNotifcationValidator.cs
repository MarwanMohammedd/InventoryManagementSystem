using FluentValidation;

namespace InventoryManagmentSystem.Features.InventoryTransactions.Event;

public class LowStockNotifcationValidator : AbstractValidator<LowStockProductNotifcation>
{
    public LowStockNotifcationValidator()
    {
        RuleFor(elemet=>elemet.ProductName)
        .NotNull()
        .NotEmpty();
    }
}