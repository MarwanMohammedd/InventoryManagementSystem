using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.Model;

namespace InventoryManagmentSystem.Shared.Repository.InventoryRepository;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplecationDBContext applicationDBContext) : base(applicationDBContext)
    {
    }
}