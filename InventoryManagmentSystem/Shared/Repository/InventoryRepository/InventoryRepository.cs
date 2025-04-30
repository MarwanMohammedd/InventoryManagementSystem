using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.Model;

namespace InventoryManagmentSystem.Shared.Repository.InventoryRepository;


public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
{
    public InventoryRepository(ApplecationDBContext applicationDBContext) : base(applicationDBContext)
    {
    }
}