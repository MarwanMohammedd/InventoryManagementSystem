using InventoryManagmentSystem.Shared.Model;

namespace InventoryManagmentSystem.Features.ProductManagement.GetAllProducts;

public class GetAllProductsResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int LowStockThreshold { get; set; }
    public int TotalQuantity { get; set; }
    public IEnumerable<InventoryDTO>? Inventories { get; set; }
}