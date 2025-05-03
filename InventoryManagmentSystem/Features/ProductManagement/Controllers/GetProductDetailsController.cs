using System.Threading.Tasks;
using InventoryManagmentSystem.Features.ProductManagement.Queries;
using InventoryManagmentSystem.Shared.APIResult;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.ProductManagement.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles="User")]
public class GetProductDetailsController : ControllerBase
{
    private readonly IMediator mediator;

    public GetProductDetailsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("[action]/{productId:int}")]
    public async Task<ActionResult> GetProductDetails(int productId)
    {
        GetProductDetailsQueryRequest requset = new GetProductDetailsQueryRequest() { ProductID = productId };
        Result<GetProductDetailsQueryResponse> result = await mediator.Send(requset);
        return Ok(result);
    }
}