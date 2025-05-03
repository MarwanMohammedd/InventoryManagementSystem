using System.Text;
using FluentValidation;
using InventoryManagmentSystem.Features.AccountManagement.Models;
using InventoryManagmentSystem.Features.AccountManagement.Services;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace InventoryManagmentSystem.Features.AccountManagement.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, Result<RegisterCommandResponse>>
{
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly IRegisterService registerService;
    private readonly IValidator<RegisterCommandRequest> validator;
    private readonly UserManager<ApplicationUser> userManager;

    public RegisterCommandHandler(SignInManager<ApplicationUser> signInManager, IRegisterService registerService, IValidator<RegisterCommandRequest> validator, UserManager<ApplicationUser> userManager)
    {
        this.signInManager = signInManager;
        this.registerService = registerService;
        this.validator = validator;
        this.userManager = userManager;
    }

    public async Task<Result<RegisterCommandResponse>> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        StringBuilder error = new();
        if (validator.Validate(request).IsValid)
        {
            bool isFirstUser = !await userManager.Users.AnyAsync();
            if (await userManager.Users.AnyAsync(u => u.Email == request.Email))
            {
                return Result<RegisterCommandResponse>.Failure("Email is already registered");
            }

            if (await userManager.Users.AnyAsync(u => u.UserName == request.UserName))
            {
                return Result<RegisterCommandResponse>.Failure("Username is already taken");
            }

            ApplicationUser applciationUser = new()
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
            };
            IdentityResult identityResult = await userManager.CreateAsync(applciationUser, request.Password);
            if (identityResult.Succeeded)
            {
                if (isFirstUser)
                {
                    await userManager.AddToRoleAsync(applciationUser, "Admin");
                }
                else
                {
                    await userManager.AddToRoleAsync(applciationUser, "User");
                }

                RegisterCommandResponse registerResponse = new()
                {
                    Token = await registerService.GenerateToken(applciationUser),
                    Message = "User Registeration Successfully"
                };
                return Result<RegisterCommandResponse>.Success(registerResponse);
            }
            else
            {
                foreach (IdentityError identityError in identityResult.Errors)
                {
                    error.Append(identityError.Description);
                }
            }
        }
        return Result<RegisterCommandResponse>.Failure(error.ToString());
    }
}