using System.Threading.Tasks;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.InventoryTransactions.TransferStock;

[ApiController]
[Route("[controller]")]
public class TransferStockController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMediator mediator;

    public TransferStockController(IUnitOfWork unitOfWork, IMediator mediator)
    {
        this.unitOfWork = unitOfWork;
        this.mediator = mediator;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> TransferStock([FromBody] TransferStockDTO transferStockDTO)
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
            await unitOfWork.SaveAsync();
            return Ok(Result<bool>.Success(true));
        }
        return BadRequest(Result<bool>.Failure("Bad Requset"));
    }

}