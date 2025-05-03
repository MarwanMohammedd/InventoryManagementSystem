using System.Threading.Tasks;
using InventoryManagmentSystem.Features.ProductManagement.Commands;
using InventoryManagmentSystem.Features.ProductManagement.DTOs;
using InventoryManagmentSystem.Shared.APIResult;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.ProductManagement.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles="User")]
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
        UpdateProductCommandRequest updateProductRequest = new () { OldProductID = productId, UpdatedProduct = product };
        Result<bool> updatedResult = await mediator.Send(updateProductRequest);
        if (updatedResult.IsSuccess)
        {
            return Ok(updatedResult);
        }
        return BadRequest(updatedResult);
    }
}