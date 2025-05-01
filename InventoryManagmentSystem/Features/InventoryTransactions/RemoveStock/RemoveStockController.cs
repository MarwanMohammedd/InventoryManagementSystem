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
    private readonly IUnitOfWork unitOfWork;
    private readonly IMediator mediator;

    public RemoveStockController(IUnitOfWork unitOfWork, IMediator mediator)
    {
        this.unitOfWork = unitOfWork;
        this.mediator = mediator;
    }
    [HttpDelete("[action]")]
    public async Task<ActionResult> RemoveStock([FromBody] RemoveStockDTO removeStockDTO)
    {
        RemoveStockRequest removeStockRequest = new() { ProductId = removeStockDTO.ProductId , Quantity = removeStockDTO.Quantity , WarehouseId = removeStockDTO.WarehouseId};
        var result = await mediator.Send(removeStockRequest);
        if (result.IsSuccess)
        {
            await unitOfWork.SaveAsync();
            return Ok(Result<bool>.Success(true));
        }
        return NotFound(Result<bool>.Failure("Inventory Is Not Exsit"));
    }
}