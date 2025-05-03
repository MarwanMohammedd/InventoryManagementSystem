using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.ProductManagement.Queries;

public class GetAllProductsQueryRequest : IRequest<Result<IEnumerable<GetAllProductsQueryResponse>>>
{
    
}