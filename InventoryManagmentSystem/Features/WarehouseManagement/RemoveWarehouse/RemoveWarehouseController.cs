using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.WarehouseManagement.RemoveWarehouse;

[ApiController]
[Route("[controller]")]
[Authorize]
public class RemoveWarehouseController : ControllerBase
{
    private readonly IMediator mediator;

    public RemoveWarehouseController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpDelete("[action]/{warehouseId:int}")]
    public async Task<ActionResult> DeleteWareHouse(int warehouseId)
    {
        RemoveWarehouseRequest removeWarehouseRequest = new() { WareHouseId = warehouseId };
        var result = await mediator.Send(removeWarehouseRequest);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}