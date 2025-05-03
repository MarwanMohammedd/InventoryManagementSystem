using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;

namespace InventoryManagmentSystem.Features.TransactionInventoryOrchestrate.TransfarStockOrchestrate;

public class TransfarStockOrchestrateRequest : IRequest<Result<bool>>
{
    public int ProductId { get; init; }
    public int WarehouseId { get; init; }
    public int Quantity { get; init; }
    public int UserId { get; set; }
    public int FromWareHouseId { get; set; }
    public int ToWareHouseId { get; set; }
}