using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.WarehouseManagement.Commands;

public class RemoveWarehouseCommandRequest : IRequest<Result<bool>>
{
    public int WareHouseId { get; init; }
}