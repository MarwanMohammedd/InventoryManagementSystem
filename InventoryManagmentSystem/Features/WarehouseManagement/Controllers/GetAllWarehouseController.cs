using System.Threading.Tasks;
using InventoryManagmentSystem.Features.WarehouseManagement.Quaries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.WarehouseManagement.Controllers;


[ApiController]
[Route("[controller]")]
[Authorize(Roles="User")]
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
        var result = await mediator.Send(new GetAllWarehouseQuaryRequest());
        return Ok(result);
    }
}