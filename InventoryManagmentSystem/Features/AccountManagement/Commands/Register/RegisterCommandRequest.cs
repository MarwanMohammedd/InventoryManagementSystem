using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.AccountManagement.Commands.Register;

public class RegisterCommandRequest : IRequest<Result<RegisterCommandResponse>>
{
    public string FirstName { get; set;} = null!;
    public string LastName { get; set;} = null!;
    public string Email { get; set;} = null!;
    public string UserName { get; set;} = null!;
    public string Password { get; set;} = null!;
}