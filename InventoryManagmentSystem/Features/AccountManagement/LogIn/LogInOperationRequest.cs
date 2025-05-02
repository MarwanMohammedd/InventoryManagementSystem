using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.AccountManagement.LogIn;

public class LogInOperationRequest : IRequest<Result<string>>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool RemeberMe { get; set; } = false;
}