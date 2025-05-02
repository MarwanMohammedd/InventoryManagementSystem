using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.CategoryManagement.GetAllCategory;


[ApiController]
[Route("[controller]")]
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