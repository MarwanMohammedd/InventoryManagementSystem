namespace InventoryManagmentSystem.Features.ProductManagement.Jobs;

public interface IDailyLowStockProducts
{
    public Task Notify();
}