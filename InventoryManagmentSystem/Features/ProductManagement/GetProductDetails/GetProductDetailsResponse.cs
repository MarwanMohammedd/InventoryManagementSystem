using InventoryManagmentSystem.Shared.Model;

namespace InventoryManagmentSystem.Features.ProductManagement.GetProductDetails;

public class GetProductDetailsResponse
{
    public int ProductID { get; set; }
    public string ProductName { get; set; } = null!;
    public int TotalQuantity { get; set; }
    public int LowStockThreshold { get; set; }
    public IEnumerable<InventoryDTO> Inventories { get; set; } = null!;
}