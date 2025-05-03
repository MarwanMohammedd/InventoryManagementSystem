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
            var AddProductRequest = new AddProductCommandRequest() 
            { CategoryId = product.CategoryId  , 
            Description = product.Description ,
             LowStockThreshold = product.LowStockThreshold ,
              Name = product.Name , Price=product.Price}; 
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