using System.Threading.Tasks;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.WarehouseManagement.AddWarehouse;


[ApiController]
[Route("[controller]")]
public class AddWarehouseController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMediator mediator;

    public AddWarehouseController(IUnitOfWork unitOfWork, IMediator mediator)
    {
        this.unitOfWork = unitOfWork;
        this.mediator = mediator;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> AddWarehouse([FromBody] AddWarehouseDTO addWarehouseDTO)
    {
        AddWarehouseRequest addWarehouseRequest = new() { Location = addWarehouseDTO.Location, Name = addWarehouseDTO.Name };
        var result = await mediator.Send(addWarehouseRequest);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}