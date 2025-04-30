using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.Model;

namespace InventoryManagmentSystem.Shared.Repository.WarehouseRepository;

public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
{
    public WarehouseRepository(ApplecationDBContext applicationDBContext) : base(applicationDBContext)
    {
    }
}