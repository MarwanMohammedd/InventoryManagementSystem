using InventoryManagmentSystem.Features.WarehouseManagement.Models;
using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.Repository;

namespace InventoryManagmentSystem.Features.WarehouseManagement.Repository;

public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
{
    public WarehouseRepository(ApplecationDBContext applicationDBContext) : base(applicationDBContext)
    {
    }
}