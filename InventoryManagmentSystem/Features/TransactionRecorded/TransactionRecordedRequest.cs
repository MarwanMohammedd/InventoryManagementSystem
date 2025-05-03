using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;

namespace InventoryManagmentSystem.Features.TransactionRecorded;

public class TransactionRecordedRequest : IRequest<Result<bool>>
{
    public TransactionType Type { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public int? FromWareHouseId { get; set; }
    public int? ToWareHouseId { get; set; }
}


