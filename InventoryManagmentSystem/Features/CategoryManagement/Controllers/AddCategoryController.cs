using System.Threading.Tasks;
using InventoryManagmentSystem.Features.CategoryManagement.Commands;
using InventoryManagmentSystem.Features.CategoryManagement.DTOs;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.CategoryManagement.Controllers;


[ApiController]
[Route("[controller]")]
[Authorize(Roles="User")]
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
            AddCategoryCommandRequest addCategoryRequest = new()
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
        return Unauthorized(Result<bool>.Failure("Invalid Input Data"));
    }
}