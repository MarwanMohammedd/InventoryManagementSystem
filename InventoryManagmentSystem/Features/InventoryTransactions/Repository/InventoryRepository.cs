using InventoryManagmentSystem.Features.InventoryTransactions.Models;
using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.Repository;

namespace InventoryManagmentSystem.Features.InventoryTransactions.Repository;

public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
{
    public InventoryRepository(ApplecationDBContext applicationDBContext) : base(applicationDBContext)
    {
    }
}