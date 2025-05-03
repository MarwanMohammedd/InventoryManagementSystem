using System.ComponentModel.DataAnnotations.Schema;
using InventoryManagmentSystem.Features.ProductManagement.Models;
using InventoryManagmentSystem.Features.WarehouseManagement.Models;

namespace InventoryManagmentSystem.Features.InventoryTransactions.Models;

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