using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;

namespace InventoryManagmentSystem.Features.TransactionInventoryOrchestrate.RemoveStockOrchestrate;


public class RemoveStockOrchestrateRequest : IRequest<Result<bool>>
{
    public int ProductId { get; init; }
    public int WarehouseId { get; init; }
    public int Quantity { get; init; }
    public int UserId { get; set; }
}