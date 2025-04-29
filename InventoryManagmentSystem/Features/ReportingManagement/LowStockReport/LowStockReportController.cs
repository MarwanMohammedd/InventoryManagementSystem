using System.Threading.Tasks;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.ReportingManagement.LowStockReport;

[ApiController]
[Route("[controller]")]
public class LowStockReportController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMediator mediator;

    public LowStockReportController(IUnitOfWork unitOfWork, IMediator mediator)
    {
        this.unitOfWork = unitOfWork;
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