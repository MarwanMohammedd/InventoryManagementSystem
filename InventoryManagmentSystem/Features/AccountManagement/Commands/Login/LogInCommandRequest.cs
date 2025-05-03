using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.AccountManagement.Commands.LogIn;

public class LogInCommandRequest : IRequest<Result<string>>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool RemeberMe { get; set; } = false;
}