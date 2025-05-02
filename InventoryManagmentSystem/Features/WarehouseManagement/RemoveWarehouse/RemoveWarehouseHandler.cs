using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;

namespace InventoryManagmentSystem.Features.WarehouseManagement.RemoveWarehouse;

public class RemoveWarehouseHandler : IRequestHandler<RemoveWarehouseRequest, Result<bool>>
{
    private readonly IUnitOfWork unitOfWork;

    public RemoveWarehouseHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<bool>> Handle(RemoveWarehouseRequest request, CancellationToken cancellationToken)
    {
        bool result = await unitOfWork.Warehouse.Delete(element=>element.ID == request.WareHouseId);
        if(result)
        {
            return Result<bool>.Success(true);
        }
        return Result<bool>.Failure("Invalid Warehouse Delete Opetation");
    }
}