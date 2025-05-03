using System.Threading.Tasks;
using InventoryManagmentSystem.Features.CategoryManagement.Commands;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.CategoryManagement.Controllers;


[ApiController]
[Route("[controller]")]
[Authorize(Roles="User")]
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
        var result = await mediator.Send(new RemoveCategoryCommandRequest() { CategoryId = categoryId });
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}