using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.CategoryManagement.GetAllCategory;

public class GetAllCategoryRequest : IRequest<Result<GetAllCategoryResponse>>
{

}