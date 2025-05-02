using System.Threading.Tasks;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.WarehouseManagement.AddWarehouse;


[ApiController]
[Route("[controller]")]
[Authorize]
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
        if (ModelState.IsValid)
        {
            AddWarehouseRequest addWarehouseRequest = new() { Location = addWarehouseDTO.Location, Name = addWarehouseDTO.Name };
            var result = await mediator.Send(addWarehouseRequest);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        return BadRequest(Result<bool>.Failure("Input Data is not valid"));
    }
}