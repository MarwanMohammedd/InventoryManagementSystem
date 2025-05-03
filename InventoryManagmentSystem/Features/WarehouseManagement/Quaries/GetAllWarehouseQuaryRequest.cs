using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.WarehouseManagement.Quaries;

public class GetAllWarehouseQuaryRequest : IRequest<Result<GetAllWarehouseQuaryResponse>>
{

}