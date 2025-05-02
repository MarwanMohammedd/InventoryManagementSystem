using System.Threading.Tasks;
using InventoryManagmentSystem.Shared.APIResult;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.CategoryManagement.RemoveCategory;


[ApiController]
[Route("[controller]")]
[Authorize]
public class RemoveCategoryController : ControllerBase
{
    private readonly IMediator mediator;

    public RemoveCategoryController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpDelete("[action]/{categoryId:int}")]
    public async Task<ActionResult> RemoveCategory(int categoryId)
    {
        var result = await mediator.Send(new RemoveCategoryRequest() { CategoryId = categoryId });
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}