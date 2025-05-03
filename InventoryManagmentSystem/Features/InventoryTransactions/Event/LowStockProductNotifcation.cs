using MediatR;

namespace InventoryManagmentSystem.Features.InventoryTransactions.Event;

public class LowStockProductNotifcation : INotification
{
    public string ProductName { get; set; } = null!;
}