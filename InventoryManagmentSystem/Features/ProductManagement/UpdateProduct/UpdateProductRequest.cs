using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using MediatR;

namespace InventoryManagmentSystem.Features.ProductManagement.UpdateProduct;

public class UpdateProductRequest : IRequest<Result<bool>>
{
    public int OldProductID { get; set; }
    public ProductDTO UpdatedProduct { get; set; } = null!;
}