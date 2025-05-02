using InventoryManagmentSystem.Shared.Model;

namespace InventoryManagmentSystem.Features.WarehouseManagement.GetAllWarehouse;
public class GetAllWarehouseResponse 
{
    public IEnumerable<Warehouse> Warehouses { get; set; } = null!;
}
