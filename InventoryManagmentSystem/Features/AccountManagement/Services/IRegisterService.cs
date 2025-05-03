using InventoryManagmentSystem.Features.AccountManagement.Models;

namespace InventoryManagmentSystem.Features.AccountManagement.Services;

public interface IRegisterService
{
    Task<string> GenerateToken(ApplicationUser user);
}