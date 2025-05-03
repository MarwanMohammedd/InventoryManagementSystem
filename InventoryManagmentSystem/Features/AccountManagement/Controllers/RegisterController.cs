using System.Threading.Tasks;
using InventoryManagmentSystem.Features.AccountManagement.Commands.Register;
using InventoryManagmentSystem.Features.AccountManagement.DTOs;
using InventoryManagmentSystem.Shared.APIResult;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.AccountManagement.Controllers;

[AllowAnonymous]
[ApiController]
[Route("[controller]")]
public class RegisterController : ControllerBase
{
    private readonly UserManager<RegisterController> userManager;
    private readonly SignInManager<RegisterController> signInManager;
    private readonly IMediator mediator;

    public RegisterController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("createAccount")]
    public async Task<ActionResult> Register([FromBody] RegisterDto registerDto)
    {
        if (ModelState.IsValid)
        {
            RegisterCommandRequest registerRequest = new()
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                Password = registerDto.Password,
            };
            var result = await mediator.Send(registerRequest);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        return BadRequest(Result<bool>.Failure("Input Data Is not Valid"));
    }
}