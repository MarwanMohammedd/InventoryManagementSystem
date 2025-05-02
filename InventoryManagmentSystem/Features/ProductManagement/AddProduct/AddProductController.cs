using System.Threading.Tasks;
using InventoryManagmentSystem.Shared.APIResult;
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
    public async Task<ActionResult> AddProduct([FromBody] ProductDTO product)
    {
        if (ModelState.IsValid)
        {
            var AddProductRequest = new AddProductRequest()
            {
                Id = product.Id,
                Description = product.Description,
                LowStockThreshold = product.LowStockThreshold,
                Name = product.Name,
                Price = product.Price
            };
            var result = await mediator.Send(AddProductRequest);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        return BadRequest(Result<bool>.Failure("Invalid Input Data"));
    }
}