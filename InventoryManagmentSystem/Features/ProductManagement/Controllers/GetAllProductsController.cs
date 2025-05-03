using System.Threading.Tasks;
using InventoryManagmentSystem.Features.ProductManagement.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.ProductManagement.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles="User")]
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
        var products = await mediator.Send(new GetAllProductsQueryRequest());
        return Ok(products);
    }
}