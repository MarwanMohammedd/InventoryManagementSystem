using System.Security.Claims;
using System.Threading.Tasks;
using InventoryManagmentSystem.Features.InventoryTransactions.Commands.AddStock;
using InventoryManagmentSystem.Features.InventoryTransactions.DTOs;
using InventoryManagmentSystem.Features.TransactionInventoryOrchestrate.AddStockOrchestrate;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.InventoryTransactions.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles="User")]
public class AddStockController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IHttpContextAccessor httpContextAccessor;

    public AddStockController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        this.mediator = mediator;
        this.httpContextAccessor = httpContextAccessor;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> AddStock([FromBody] AddStockDTO addStockDTO)
    {
        var userId = httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId is null)
        {
            return BadRequest(Result<bool>.Failure("User ID Not Exists"));
        }

        AddStockOrchestrateOrchestrateRequest addStockOrchestrateOrchestrateRequest = new()
        {
            ProductId = addStockDTO.ProductId,
            Quantity = addStockDTO.Quantity,
            WarehouseId = addStockDTO.WarehouseId,
            UserId = Convert.ToInt32(userId.ToString())
        };

        Result<bool> result = await mediator.Send(addStockOrchestrateOrchestrateRequest);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}