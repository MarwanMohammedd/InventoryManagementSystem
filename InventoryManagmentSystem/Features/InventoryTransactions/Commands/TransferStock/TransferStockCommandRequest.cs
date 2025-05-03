using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.InventoryTransactions.Commands.TransferStock;

public class TransferStockCommandRequest : IRequest<Result<bool>>
{
    public int ProductId { get; init; }
    public int Quantity { get; init; }
    public int ToWareHouseId { get; init; }
    public int FromWareHouseId { get; init; }
}