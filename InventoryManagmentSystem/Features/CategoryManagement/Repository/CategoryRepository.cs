using InventoryManagmentSystem.Features.CategoryManagement.Models;
using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.Repository;
using InventoryManagmentSystem.Shared.Repository.InventoryRepository;

namespace InventoryManagmentSystem.Features.CategoryManagement.Repository;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplecationDBContext applicationDBContext) : base(applicationDBContext)
    {
    }
}