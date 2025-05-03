using System.Threading.Tasks;
using InventoryManagmentSystem.Features.CategoryManagement.Queries;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.CategoryManagement.Controllers;


[ApiController]
[Route("[controller]")]
[Authorize(Roles = "User")]
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
        var result = await mediator.Send(new GetAllCategoryQueryRequest());
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}