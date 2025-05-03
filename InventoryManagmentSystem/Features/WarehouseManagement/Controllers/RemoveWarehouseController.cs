using System.Threading.Tasks;
using InventoryManagmentSystem.Features.WarehouseManagement.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.WarehouseManagement.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles="User")]
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
        RemoveWarehouseCommandRequest removeWarehouseRequest = new() { WareHouseId = warehouseId };
        var result = await mediator.Send(removeWarehouseRequest);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}