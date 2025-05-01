using InventoryManagmentSystem.Shared.APIResult;
using MediatR;
namespace InventoryManagmentSystem.Features.InventoryTransactions.AddStock;

public class AddStockRequest : IRequest<Result<bool>>
{
    public int ProductId { get; init; }
    public int WarehouseId { get; init; }
    public int Quantity { get; init; }
}