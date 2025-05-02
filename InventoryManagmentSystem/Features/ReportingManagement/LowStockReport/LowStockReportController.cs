using System.Threading.Tasks;
using InventoryManagmentSystem.Shared.UnitOfWork;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.ReportingManagement.LowStockReport;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = Roles.Admin)]

public class LowStockReportController : ControllerBase
{
    private readonly IMediator mediator;

    public LowStockReportController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult> GetLowStockProducts()
    {
        var request = new LowStockReportRequest();
        var result = await mediator.Send(request);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}