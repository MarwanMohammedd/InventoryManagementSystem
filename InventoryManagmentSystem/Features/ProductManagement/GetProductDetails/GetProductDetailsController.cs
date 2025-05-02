using System.Threading.Tasks;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.ProductManagement.GetProductDetails;

[ApiController]
[Route("[controller]")]
[Authorize]
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
        GetProductDetailsRequest requset = new GetProductDetailsRequest() { ProductID = productId };
        Result<GetProductDetailsResponse> result = await mediator.Send(requset);
        return Ok(result);
    }
}