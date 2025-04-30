namespace InventoryManagmentSystem.Shared.Model;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int LowStockThreshold { get; set; }
    public IEnumerable<Inventory>? Inventories { get; set; }
}