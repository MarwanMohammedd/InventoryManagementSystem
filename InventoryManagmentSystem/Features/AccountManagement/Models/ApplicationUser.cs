using InventoryManagmentSystem.Features.ReportingManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagmentSystem.Features.AccountManagement.Models;

public class ApplicationUser : IdentityUser<int>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public IEnumerable<TransactionEntity>? Transactions { get; set; }
}