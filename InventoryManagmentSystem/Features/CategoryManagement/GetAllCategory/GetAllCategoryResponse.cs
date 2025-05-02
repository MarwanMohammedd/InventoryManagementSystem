using InventoryManagmentSystem.Shared.Model;

namespace InventoryManagmentSystem.Features.CategoryManagement.GetAllCategory;

public class GetAllCategoryResponse
{
    public IEnumerable<Category> Categories { get; set; } = null!;
}