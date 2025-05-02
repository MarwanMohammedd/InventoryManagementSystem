using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.CategoryManagement.GetAllCategory;


[ApiController]
[Route("[controller]")]
[Authorize]
public class GetAllCategoryController : ControllerBase
{
    private readonly IMediator mediator;

    public GetAllCategoryController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllCategoryRequest());
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}