using InventoryManagmentSystem.Shared.APIResult;
using MediatR;
namespace InventoryManagmentSystem.Features.ProductManagement.Commands;
public class RemoveProductCommandRequest : IRequest<Result<bool>>
{
    public int ProductId { get; init; }
}