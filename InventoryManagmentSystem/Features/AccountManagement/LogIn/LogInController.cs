using System.Threading.Tasks;
using InventoryManagmentSystem.Shared.APIResult;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.AccountManagement.LogIn;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class LogInController : ControllerBase
{
    private readonly IMediator mediator;

    public LogInController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpPost]
    public async Task<ActionResult> LogIn([FromBody] LogInDto logInDto)
    {
        if (ModelState.IsValid)
        {
            LogInOperationRequest loginRequest = new()
            {
                Email = logInDto.Email,
                Password = logInDto.Password,
                RemeberMe = logInDto.RemeberMe,
            };
            var result = await mediator.Send(loginRequest);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        return BadRequest(Result<string>.Failure("Log In Operation Is Faild"));
    }
}