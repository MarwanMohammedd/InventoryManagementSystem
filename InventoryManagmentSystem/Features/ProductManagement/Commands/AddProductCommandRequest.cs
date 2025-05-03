using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.ProductManagement.Commands;

public class AddProductCommandRequest : IRequest<Result<string>>
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int LowStockThreshold { get; set; }
}