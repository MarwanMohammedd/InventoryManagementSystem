namespace InventoryManagmentSystem.Features.ReportingManagement.LowStockReport;

public class LowStockReportResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int TotalQuantity { get; set; }
    public int LowStockThreshold { get; set; }
    public IEnumerable<InventoryDTO>? Inventories { get; set; }
}