using System.Threading.Tasks;
using InventoryManagmentSystem.Shared.APIResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.ReportingManagement.TransactionHistory;

[ApiController]
[Route("[controller]")]
public class TransactionHistoryController : ControllerBase
{
    private readonly IMediator mediator;

    public TransactionHistoryController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("GetTransactionHistory")]
    public async Task<ActionResult> TransactionHistory([FromQuery] TransactionHistoryDTO transactionHistoryDTO)
    {
        TransactionHistoryRequest transactionHistoryRequest = new()
        {
            TransactionType = transactionHistoryDTO.TransactionType,
            FromDate = transactionHistoryDTO.FromDate,
            ToDate = transactionHistoryDTO.ToDate,
            ProductCategory = transactionHistoryDTO.ProductCategory,
            ProductId = transactionHistoryDTO.ProductId,
        };
        var result = await mediator.Send(transactionHistoryRequest);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}