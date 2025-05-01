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

    [HttpGet]
    public ActionResult TransactionHistory()
    {
        return Ok();
    }
}