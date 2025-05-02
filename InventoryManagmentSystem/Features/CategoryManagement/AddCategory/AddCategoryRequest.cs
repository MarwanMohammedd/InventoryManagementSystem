using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.CategoryManagement.AddCategory;

public class AddCategoryRequest : IRequest<Result<bool>>
{
    public  string CategoryName { get; set; } = null!;
}