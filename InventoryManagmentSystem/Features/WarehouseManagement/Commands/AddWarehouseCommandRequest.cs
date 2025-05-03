using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.WarehouseManagement.Commands;

public class AddWarehouseCommandRequest : IRequest<Result<bool>>
{
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
}