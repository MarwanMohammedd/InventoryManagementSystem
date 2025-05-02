using MediatR;

namespace InventoryManagmentSystem.Features.LowStockNotifcation;

public class LowStockProductNotifcation : INotification
{
    public string ProductName { get; set; } = null!;
}