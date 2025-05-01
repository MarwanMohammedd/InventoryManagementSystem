using FluentValidation;

namespace InventoryManagmentSystem.Features.WarehouseManagement.AddWarehouse;

public class AddWarehouseValidator : AbstractValidator<AddWarehouseRequest>
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
}