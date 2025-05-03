using System.Threading.Tasks;
using InventoryManagmentSystem.Features.ReportingManagement.Quaries.LowStock;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.ReportingManagement.LowStockReport;

[ApiController]
[Route("[controller]")]
[Authorize(Roles="Admin")]

public class LowStockReportController : ControllerBase
{
    private readonly IMediator mediator;

    public LowStockReportController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult> GetLowStockProducts([FromQuery] int pageSize = 10,[FromQuery] int page = 1)
    {
        var request = new LowStockReportQuaryRequest(){PageSize = pageSize , Page = page};
        var result = await mediator.Send(request);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}