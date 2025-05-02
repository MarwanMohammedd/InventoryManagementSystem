using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.WarehouseManagement.GetAllWarehouse;


[ApiController]
[Route("[controller]")]
public class GetAllWarehouseController : ControllerBase
{
    private readonly IMediator mediator;

    public GetAllWarehouseController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllWarehouse()
    {
        var result = await mediator.Send(new GetAllWarehouseRequest());
        return Ok(result);
    }
}