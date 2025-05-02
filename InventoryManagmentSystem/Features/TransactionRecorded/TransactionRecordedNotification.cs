using InventoryManagmentSystem.Shared.Utilities;
using MediatR;

namespace InventoryManagmentSystem.Features.TransactionRecorded;

public class TransactionRecordedNotification : INotification
{

    public TransactionType Type { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public string ProductCategory { get; set; } = null!;

    public string UserName { get; set; } = null!;
    public int? FromWareHouseId { get; set; }
    public int? ToWareHouseId { get; set; }
}


