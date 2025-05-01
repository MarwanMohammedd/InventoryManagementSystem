namespace InventoryManagmentSystem.Features.InventoryTransactions.TransferStock;

public class TransferStockDTO
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int ToWareHouseId { get; set; }
    public int FromWareHouseId { get; set; }
}