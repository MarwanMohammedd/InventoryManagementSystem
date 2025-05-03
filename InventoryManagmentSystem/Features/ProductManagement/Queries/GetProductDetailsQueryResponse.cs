using InventoryManagmentSystem.Features.ProductManagement.DTOs;

namespace InventoryManagmentSystem.Features.ProductManagement.Queries;

public class GetProductDetailsQueryResponse
{
    public int ProductID { get; set; }
    public string ProductName { get; set; } = null!;
    public string ProductCategory { get; set; } = null!;
    public int TotalQuantity { get; set; }
    public int LowStockThreshold { get; set; }
    public IEnumerable<InventoryDTO> Inventories { get; set; } = null!;
}