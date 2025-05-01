using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.WarehouseManagement.RemoveWarehouse;

public class RemoveWarehouseHandler : IRequestHandler<RemoveWarehouseRequest, Result<bool>>
{
    public Task<Result<bool>> Handle(RemoveWarehouseRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}