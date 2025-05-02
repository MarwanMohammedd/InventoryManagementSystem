using System.Threading.Tasks;
using InventoryManagmentSystem.Shared.APIResult;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.CategoryManagement.AddCategory;


[ApiController]
[Route("[controller]")]
[Authorize]
public class AddCategoryController : ControllerBase
{
    private readonly IMediator mediator;

    public AddCategoryController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> AddCategory([FromBody] CategoryDTO categoryDTO)
    {
        if (ModelState.IsValid)
        {
            AddCategoryRequest addCategoryRequest = new()
            {
                CategoryName = categoryDTO.CategoryName
            };
            var result = await mediator.Send(addCategoryRequest);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        return BadRequest(Result<bool>.Failure("Invalid Input Data"));
    }
}