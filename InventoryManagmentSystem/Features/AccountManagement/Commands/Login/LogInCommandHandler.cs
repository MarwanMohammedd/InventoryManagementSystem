using System.Text;
using FluentValidation;
using InventoryManagmentSystem.Features.AccountManagement.Models;
using InventoryManagmentSystem.Features.AccountManagement.Services;
using InventoryManagmentSystem.Shared.APIResult;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagmentSystem.Features.AccountManagement.Commands.LogIn;

public class LogInCommandHandler : IRequestHandler<LogInCommandRequest, Result<string>>
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IValidator<LogInCommandRequest> validator;
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly IRegisterService registerService;

    public LogInCommandHandler( IRegisterService registerService,UserManager<ApplicationUser> userManager, IValidator<LogInCommandRequest> validator, SignInManager<ApplicationUser> signInManager)
    {
        this.registerService = registerService;
        this.userManager = userManager;
        this.validator = validator;
        this.signInManager = signInManager;
    }
    public async Task<Result<string>> Handle(LogInCommandRequest request, CancellationToken cancellationToken)
    {
        if (validator.Validate(request).IsValid)
        {
            ApplicationUser? user = await userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                return Result<string>.Failure("User not found");
            }
            
            SignInResult signInResult = await signInManager.PasswordSignInAsync(user.UserName, request.Password, isPersistent: request.RemeberMe, lockoutOnFailure: false);

            if (signInResult.Succeeded)
            {
                string Token = await registerService.GenerateToken(user);
                return Result<string>.Success(Token);
            }
            else
            {
                return Result<string>.Failure("Log In Operation Is Faild");
            }

        }
        return Result<string>.Failure("User Log In Credintial Is Not Valid");
    }
}