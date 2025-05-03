using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.CategoryManagement.Commands;

public class AddCategoryCommandRequest : IRequest<Result<bool>>
{
    public  string CategoryName { get; set; } = null!;
}