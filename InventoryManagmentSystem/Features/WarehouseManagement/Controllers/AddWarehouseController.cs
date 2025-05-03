using System.Threading.Tasks;
using InventoryManagmentSystem.Features.WarehouseManagement.Commands;
using InventoryManagmentSystem.Features.WarehouseManagement.DTOs;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.WarehouseManagement.Controllers;


[ApiController]
[Route("[controller]")]
[Authorize(Roles="User")]
public class AddWarehouseController : ControllerBase
{
    private readonly IMediator mediator;

    public AddWarehouseController( IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> AddWarehouse([FromBody] AddWarehouseDTO addWarehouseDTO)
    {
        if (ModelState.IsValid)
        {
            AddWarehouseCommandRequest addWarehouseRequest = new() { Location = addWarehouseDTO.Location, Name = addWarehouseDTO.Name };
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