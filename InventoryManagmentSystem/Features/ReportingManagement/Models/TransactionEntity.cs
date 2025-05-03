using System.ComponentModel.DataAnnotations.Schema;
using InventoryManagmentSystem.Features.AccountManagement.Models;
using InventoryManagmentSystem.Features.ProductManagement.Models;
using InventoryManagmentSystem.Features.WarehouseManagement.Models;
using InventoryManagmentSystem.Shared.Utilities;

namespace InventoryManagmentSystem.Features.ReportingManagement.Models;
public class TransactionEntity
{
    public int Id { get; set; }
    public TransactionType Type { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public int? FromWarehouseId { get; set; } 
    public int? ToWarehouseId { get; set; }  
    public string ProductCategory { get; set; }  = null!;
    
    [ForeignKey("User")]
    public int UserId { get; set; }
    public Product? Product { get; set; }
    public Warehouse? FromWarehouse { get; set; }
    public Warehouse? ToWarehouse { get; set; }
    public ApplicationUser? User { get; set; }
    public bool IsArchived { get; set; } = false;
}