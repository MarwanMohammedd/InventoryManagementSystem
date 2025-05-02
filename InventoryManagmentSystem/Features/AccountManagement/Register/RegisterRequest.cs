using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.AccountManagement.Register;

public class RegisterRequest : IRequest<Result<RegisterResponse>>
{
    public string FirstName { get; set;}
    public string LastName { get; set;}
    public string Email { get; set;}
    public string UserName { get; set;}
    public string Password { get; set;}
}