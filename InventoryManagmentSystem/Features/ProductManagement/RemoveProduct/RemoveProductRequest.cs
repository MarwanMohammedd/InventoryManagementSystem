using InventoryManagmentSystem.Shared.APIResult;
using MediatR;
namespace InventoryManagmentSystem.Features.ProductManagement.RemoveProduct;
public class RemoveProductRequest : IRequest<Result<bool>>
{
    public int ProductId { get; init; }
}