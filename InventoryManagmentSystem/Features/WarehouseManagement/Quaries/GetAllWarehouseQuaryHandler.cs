using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace InventoryManagmentSystem.Features.WarehouseManagement.Quaries;

public class GetAllWarehouseHandler : IRequestHandler<GetAllWarehouseQuaryRequest, Result<GetAllWarehouseQuaryResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetAllWarehouseHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<GetAllWarehouseQuaryResponse>> Handle(GetAllWarehouseQuaryRequest request, CancellationToken cancellationToken)
    {
        GetAllWarehouseQuaryResponse getAllWarehouseResponse = new()
        {
            Warehouses = await unitOfWork.Warehouse.ReadAllAsync()
        };

        return Result<GetAllWarehouseQuaryResponse>.Success(getAllWarehouseResponse);
    }
}