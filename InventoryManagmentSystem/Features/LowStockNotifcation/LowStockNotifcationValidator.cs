using FluentValidation;

namespace InventoryManagmentSystem.Features.LowStockNotifcation;

public class LowStockNotifcationValidator : AbstractValidator<LowStockProductNotifcation>
{
    public LowStockNotifcationValidator()
    {
        RuleFor(elemet=>elemet.ProductName).NotNull().NotEmpty();
    }
}