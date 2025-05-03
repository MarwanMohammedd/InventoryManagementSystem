namespace InventoryManagmentSystem.Features.ProductManagement.DTOs;


public class ProductDTO 
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int LowStockThreshold { get; set; }
}