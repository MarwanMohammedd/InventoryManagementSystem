using FluentValidation;

namespace InventoryManagmentSystem.Features.WarehouseManagement.AddWarehouse;

public class AddWarehouseValidator : AbstractValidator<AddWarehouseRequest>
{
    public AddWarehouseValidator()
    {
        RuleFor(element=>element.Name).NotEmpty().NotNull().WithMessage("WareHouse Name is not valid");
        RuleFor(element=>element.Location).NotEmpty().NotNull().WithMessage("WareHouse Location is not valid");
    }
}