using System.Security.Claims;
using System.Threading.Tasks;
using InventoryManagmentSystem.Features.InventoryTransactions.Commands.TransferStock;
using InventoryManagmentSystem.Features.InventoryTransactions.DTOs;
using InventoryManagmentSystem.Features.TransactionInventoryOrchestrate.TransfarStockOrchestrate;
using InventoryManagmentSystem.Shared.APIResult;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.InventoryTransactions.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles="User")]

public class TransferStockController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IHttpContextAccessor httpContextAccessor;

    public TransferStockController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        this.mediator = mediator;
        this.httpContextAccessor = httpContextAccessor;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> TransferStock([FromBody] TransferStockDTO transferStockDTO)
    {
        if (ModelState.IsValid)
        {
            var userId = httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value ?? null;

            if (userId is null)
            {
                return BadRequest(Result<bool>.Failure("User ID Not Exists"));
            }

            TransfarStockOrchestrateRequest transfarStockOrchestrateRequest =
             new()
             {
                 ProductId = transferStockDTO.ProductId,
                 Quantity = transferStockDTO.Quantity,
                 FromWareHouseId = transferStockDTO.FromWareHouseId,
                 ToWareHouseId = transferStockDTO.ToWareHouseId,
                 UserId = Convert.ToInt32(userId.ToString())
             };

            var result = await mediator.Send(transfarStockOrchestrateRequest);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        return BadRequest(Result<bool>.Failure("Input Data is not valid"));
    }

}