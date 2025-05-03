using InventoryManagmentSystem.Features.ProductManagement.DTOs;

namespace InventoryManagmentSystem.Features.ReportingManagement.Quaries.LowStock;

public class LowStockReportQuaryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int TotalQuantity { get; set; }
    public int LowStockThreshold { get; set; }
    public IEnumerable<InventoryDTO>? Inventories { get; set; }
    public int TotalPage { get; set; }
}