using System.Security.Claims;
using System.Threading.Tasks;
using InventoryManagmentSystem.Features.InventoryTransactions.Commands.RemoveStock;
using InventoryManagmentSystem.Features.InventoryTransactions.DTOs;
using InventoryManagmentSystem.Features.TransactionInventoryOrchestrate.RemoveStockOrchestrate;
using InventoryManagmentSystem.Shared.APIResult;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.InventoryTransactions.Controllers;


[ApiController]
[Route("[controller]")]
[Authorize(Roles="User")]
public class RemoveStockController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IHttpContextAccessor httpContextAccessor;

    public RemoveStockController(IMediator mediator , IHttpContextAccessor httpContextAccessor)
    {
        this.mediator = mediator;
        this.httpContextAccessor = httpContextAccessor;
    }
    [HttpDelete("[action]")]
    public async Task<ActionResult> RemoveStock([FromBody] RemoveStockDTO removeStockDTO)
    {
        if (ModelState.IsValid)
        {
            var userId = httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value ?? null;
            
            if(userId is null)
            {
                return BadRequest(Result<bool>.Failure("User ID Not Exists"));
            }

            RemoveStockOrchestrateRequest removeStockOrchestrateRequest = new()
            { ProductId = removeStockDTO.ProductId ,
             Quantity = removeStockDTO.Quantity ,
              WarehouseId = removeStockDTO.WarehouseId,
              UserId = Convert.ToInt32(userId.ToString()),
            };
            var result = await mediator.Send(removeStockOrchestrateRequest);
            if (result.IsSuccess)
            {
                return Ok(Result<bool>.Success(true));
            }
        }
        return NotFound(Result<bool>.Failure("Inventory Is Not Exsit"));
    }
}