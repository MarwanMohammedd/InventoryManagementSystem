using FluentValidation;
using InventoryManagmentSystem.Features.WarehouseManagement.Commands;

namespace InventoryManagmentSystem.Features.WarehouseManagement.Validators;

public class AddWarehouseValidator : AbstractValidator<AddWarehouseCommandRequest>
{
    public AddWarehouseValidator()
    {
        RuleFor(element=>element.Name).NotEmpty().NotNull().WithMessage("WareHouse Name is not valid");
        RuleFor(element=>element.Location).NotEmpty().NotNull().WithMessage("WareHouse Location is not valid");
    }
}