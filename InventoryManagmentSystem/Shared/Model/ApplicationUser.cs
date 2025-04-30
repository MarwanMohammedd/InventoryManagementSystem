using Microsoft.AspNetCore.Identity;

namespace InventoryManagmentSystem.Shared.Model;

public class ApplicationUser : IdentityUser<int>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public IEnumerable<Transaction>? Transactions { get; set; }
}