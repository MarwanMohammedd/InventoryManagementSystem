using System.ComponentModel.DataAnnotations.Schema;
using InventoryManagmentSystem.Features.CategoryManagement.Models;
using InventoryManagmentSystem.Features.InventoryTransactions.Models;

namespace InventoryManagmentSystem.Features.ProductManagement.Models;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int LowStockThreshold { get; set; }
    public IEnumerable<Inventory>? Inventories { get; set; }

    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}