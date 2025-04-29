using System.Threading.Tasks;
using InventoryManagmentSystem.Shared.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.ProductManagement.AddProduct;

[ApiController]
[Route("[controller]")]
public class AddProductController : ControllerBase
{
    private readonly IMediator mediator;

    public AddProductController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> AddProduct([FromBody] Product product)
    {
        var AddProductRequest = new AddProductRequest() { NewProduct = product };
        var result = await mediator.Send(AddProductRequest);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}