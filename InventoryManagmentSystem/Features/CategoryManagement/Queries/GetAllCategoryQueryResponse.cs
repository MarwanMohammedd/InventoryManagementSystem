using InventoryManagmentSystem.Features.CategoryManagement.DTOs;
using InventoryManagmentSystem.Features.CategoryManagement.Models;

namespace InventoryManagmentSystem.Features.CategoryManagement.Queries;

public class GetAllCategoryQueryResponse
{
    public IEnumerable<CategoryDTO> Categories { get; set; } = null!;
}