namespace InventoryManagmentSystem.Features.InventoryTransactions.DTOs;

public class TransferStockDTO
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int ToWareHouseId { get; set; }
    public int FromWareHouseId { get; set; }
}