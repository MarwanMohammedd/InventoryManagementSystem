using InventoryManagmentSystem.Features.ProductManagement.DTOs;

namespace InventoryManagmentSystem.Features.ProductManagement.Queries;

public class GetAllProductsQueryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int LowStockThreshold { get; set; }
    public string ProductCategory { get; set; } = null!;
    public int TotalQuantity { get; set; }
    public IEnumerable<InventoryDTO>? Inventories { get; set; }
}