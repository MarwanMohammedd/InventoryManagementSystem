using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.WarehouseManagement.RemoveWarehouse;

public class RemoveWarehouseRequest : IRequest<Result<bool>>
{
    public int WareHouseId { get; init; }
}