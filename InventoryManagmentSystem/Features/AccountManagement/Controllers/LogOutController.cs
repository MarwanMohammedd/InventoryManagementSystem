using System.Threading.Tasks;
using InventoryManagmentSystem.Features.AccountManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.AccountManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class LogOutController : ControllerBase
{
    private readonly SignInManager<ApplicationUser> signInManager;

    public LogOutController(SignInManager<ApplicationUser> signInManager)
    {
        this.signInManager = signInManager;
    }
    [HttpGet("SignOut")]
    public async Task<ActionResult> LogOut()
    {
        await signInManager.SignOutAsync();
        return Ok();
    }
}