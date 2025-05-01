using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.WarehouseManagement.AddWarehouse;

public class AddWarehouseRequest : IRequest<Result<bool>>
{
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
}