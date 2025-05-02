using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.ProductManagement.GetAllProducts;

[ApiController]
[Route("[controller]")]
[Authorize]
public class GetAllProductsController : ControllerBase
{
    private readonly IMediator mediator;

    public GetAllProductsController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpGet]
    public async Task<ActionResult> GetAllProducts()
    {
        var requset = new GetAllProductsRequest();
        var products = await mediator.Send(requset);
        return Ok(products);
    }
}