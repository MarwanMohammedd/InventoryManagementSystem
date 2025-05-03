using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace InventoryManagmentSystem.Features.WarehouseManagement.Commands;

public class RemoveWarehouseCommandHandler : IRequestHandler<RemoveWarehouseCommandRequest, Result<bool>>
{
    private readonly IUnitOfWork unitOfWork;

    public RemoveWarehouseCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<bool>> Handle(RemoveWarehouseCommandRequest request, CancellationToken cancellationToken)
    {
        bool result = await unitOfWork.Warehouse.Delete(element => element.ID == request.WareHouseId);
        if (result)
        {
            await unitOfWork.SaveChangesAsync();

            return Result<bool>.Success(true);
        }
        return Result<bool>.Failure("Invalid Warehouse Delete Opetation");
    }
}