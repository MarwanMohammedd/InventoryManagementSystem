using InventoryManagmentSystem.Features.ProductManagement.DTOs;
using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.ProductManagement.Commands;

public class UpdateProductCommandRequest : IRequest<Result<bool>>
{
    public int OldProductID { get; set; }
    public ProductDTO UpdatedProduct { get; set; } = null!;
}