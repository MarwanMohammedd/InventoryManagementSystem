using System.Threading.Tasks;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.InventoryTransactions.TransferStock;

[ApiController]
[Route("[controller]")]
[Authorize]

public class TransferStockController : ControllerBase
{
    private readonly IMediator mediator;

    public TransferStockController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> TransferStock([FromBody] TransferStockDTO transferStockDTO)
    {
        if (ModelState.IsValid)
        {
            TransferStockRequest transferStockRequest = new TransferStockRequest()
            {
                ProductId = transferStockDTO.ProductId,
                Quantity = transferStockDTO.Quantity,
                FromWareHouseId = transferStockDTO.FromWareHouseId,
                ToWareHouseId = transferStockDTO.ToWareHouseId
            };
            var result = await mediator.Send(transferStockRequest);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        return BadRequest(Result<bool>.Failure("Input Data is not valid"));
    }

}