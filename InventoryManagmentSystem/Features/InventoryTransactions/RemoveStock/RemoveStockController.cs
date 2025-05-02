using System.Threading.Tasks;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.InventoryTransactions.RemoveStock;

[ApiController]
[Route("[controller]")]
public class RemoveStockController : ControllerBase
{
    private readonly IMediator mediator;

    public RemoveStockController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpDelete("[action]")]
    public async Task<ActionResult> RemoveStock([FromBody] RemoveStockDTO removeStockDTO)
    {
        if (ModelState.IsValid)
        {
            RemoveStockRequest removeStockRequest = new() { ProductId = removeStockDTO.ProductId, Quantity = removeStockDTO.Quantity, WarehouseId = removeStockDTO.WarehouseId };
            var result = await mediator.Send(removeStockRequest);
            if (result.IsSuccess)
            {
                return Ok(Result<bool>.Success(true));
            }
        }
        return NotFound(Result<bool>.Failure("Inventory Is Not Exsit"));
    }
}