using System.Threading.Tasks;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.ProductManagement.UpdateProduct;

[ApiController]
[Route("[controller]")]
public class UpdateProductController : ControllerBase
{
    private readonly IMediator mediator;
    public UpdateProductController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPut("[action]/{productId:int}")]
    public async Task<ActionResult> UpdateProduct([FromRoute] int productId, [FromBody] ProductDTO product)
    {
        UpdateProductRequest updateProductRequest = new UpdateProductRequest() { OldProductID = productId, UpdatedProduct = product };
        Result<bool> updatedResult = await mediator.Send(updateProductRequest);
        if (updatedResult.IsSuccess)
        {
            return Ok(updatedResult);
        }
        return BadRequest(updatedResult);
    }
}