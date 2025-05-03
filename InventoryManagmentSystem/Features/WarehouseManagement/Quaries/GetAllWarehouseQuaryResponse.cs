using InventoryManagmentSystem.Features.WarehouseManagement.Models;

namespace InventoryManagmentSystem.Features.WarehouseManagement.Quaries;
public class GetAllWarehouseQuaryResponse 
{
    public IEnumerable<Warehouse> Warehouses { get; set; } = null!;
}
