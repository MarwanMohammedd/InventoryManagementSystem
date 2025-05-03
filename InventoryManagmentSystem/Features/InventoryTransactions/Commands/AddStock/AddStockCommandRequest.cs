using InventoryManagmentSystem.Shared.APIResult;
using MediatR;
namespace InventoryManagmentSystem.Features.InventoryTransactions.Commands.AddStock;

public class AddStockCommandRequest : IRequest<Result<bool>>
{
    public int ProductId { get; init; }
    public int WarehouseId { get; init; }
    public int Quantity { get; init; }
}