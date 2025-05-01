namespace InventoryManagmentSystem.Features.InventoryTransactions.RemoveStock;

public class RemoveStockDTO
{
    public int ProductId { get; set; }
    public int WarehouseId { get; set; }
    public int Quantity { get; set; }
}