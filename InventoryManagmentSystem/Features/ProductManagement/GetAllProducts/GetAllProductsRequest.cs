using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using MediatR;

namespace InventoryManagmentSystem.Features.ProductManagement.GetAllProducts;

public class GetAllProductsRequest : IRequest<Result<IEnumerable<GetAllProductsResponse>>>
{
    
}