using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.CategoryManagement.Commands;

public class RemoveCategoryCommandRequest : IRequest<Result<string>>
{
    public int CategoryId{ get; set; }
}