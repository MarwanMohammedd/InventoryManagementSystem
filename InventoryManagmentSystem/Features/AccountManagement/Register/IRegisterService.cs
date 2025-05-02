using InventoryManagmentSystem.Shared.Model;

namespace InventoryManagmentSystem.Features.AccountManagement.Register;

public interface IRegisterService
{
    Task<string> GenerateToken(ApplicationUser user);
}