using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.CategoryManagement.Queries;

public class GetAllCategoryQueryRequest : IRequest<Result<GetAllCategoryQueryResponse>>
{

}