using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using MediatR;

namespace InventoryManagmentSystem.Features.ProductManagement.AddProduct;

public class AddProductRequest : IRequest<Result<Product>>
{
    public ProductDTO NewProduct { get; set; } = null!;
}