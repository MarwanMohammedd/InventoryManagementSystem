using System.Threading.Tasks;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.InventoryTransactions.AddStock;

[ApiController]
[Route("[controller]")]
[Authorize]
public class AddStockController : ControllerBase
{
    private readonly IMediator mediator;

    public AddStockController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> AddStock([FromBody] AddStockDTO addStockDTO)
    {
        AddStockRequest addStockRequest = new() { ProductId = addStockDTO.ProductId, Quantity = addStockDTO.Quantity, WarehouseId = addStockDTO.WarehouseId };
        Result<bool> result = await mediator.Send(addStockRequest);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}