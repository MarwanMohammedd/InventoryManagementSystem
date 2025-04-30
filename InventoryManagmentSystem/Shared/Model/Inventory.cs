using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagmentSystem.Shared.Model;

public class Inventory
{
    [ForeignKey("Product")]
    public int ProductId { get; set; }  
    [ForeignKey("Warehouse")]
    public int WarehouseId { get; set; } 
    public int Quantity { get; set; }
    public Product? Product { get; set; }
    public Warehouse? Warehouse { get; set; }
}