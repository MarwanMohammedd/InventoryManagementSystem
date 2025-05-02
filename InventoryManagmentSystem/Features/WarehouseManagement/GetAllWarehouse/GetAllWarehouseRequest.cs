using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.WarehouseManagement.GetAllWarehouse;

public class GetAllWarehouseRequest : IRequest<Result<GetAllWarehouseResponse>>
{

}