using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using MediatR;

namespace InventoryManagmentSystem.Features.ProductManagement.GetProductDetails;

public class GetProductDetailsRequest : IRequest<Result<GetProductDetailsResponse>>
{
    public int ProductID { get; init; }
}