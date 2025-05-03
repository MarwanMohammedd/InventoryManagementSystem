namespace InventoryManagmentSystem.Features.InventoryTransactions.DTOs;

public class RemoveStockDTO
{
    public int ProductId { get; set; }
    public int WarehouseId { get; set; }
    public int Quantity { get; set; }
}