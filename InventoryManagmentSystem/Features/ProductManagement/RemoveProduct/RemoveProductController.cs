using InventoryManagmentSystem.Shared.APIResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.ProductManagement.RemoveProduct;

[ApiController]
[Route("[controller]")]
public class RemoveProductController : ControllerBase
{
    private readonly IMediator mediator;

    public RemoveProductController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpDelete("[action]/{productId:int}")]
    public async Task<ActionResult> RemoveProduct(int productId)
    {
        RemoveProductRequest removeProductRequest = new(){ProductId = productId};
        if (ModelState.IsValid)
        {
            Result<bool> result = await mediator.Send(removeProductRequest);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
        }
        return NotFound(Result<bool>.Failure("SomeThing Wrong"));
    }
}