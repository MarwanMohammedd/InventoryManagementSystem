using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.ProductManagement.Queries;

public class GetProductDetailsQueryRequest : IRequest<Result<GetProductDetailsQueryResponse>>
{
    public int ProductID { get; init; }
}