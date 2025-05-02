using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;

namespace InventoryManagmentSystem.Features.WarehouseManagement.GetAllWarehouse;

public class GetAllWarehouseHandler : IRequestHandler<GetAllWarehouseRequest, Result<GetAllWarehouseResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetAllWarehouseHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<GetAllWarehouseResponse>> Handle(GetAllWarehouseRequest request, CancellationToken cancellationToken)
    {
        GetAllWarehouseResponse getAllWarehouseResponse = new()
        {
            Warehouses = await unitOfWork.Warehouse.ReadAllAsync()
        };

        return Result<GetAllWarehouseResponse>.Success(getAllWarehouseResponse);
    }
}