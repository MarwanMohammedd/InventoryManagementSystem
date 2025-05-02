using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.CategoryManagement.RemoveCategory;

public class RemoveCategoryRequest : IRequest<Result<string>>
{
    public int CategoryId{ get; set; }
}