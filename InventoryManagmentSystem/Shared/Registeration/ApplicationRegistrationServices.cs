using InventoryManagmentSystem.Shared.Data;

namespace InventoryManagmentSystem.Shared.Registeration;

public static class ApplicationRegistrationExtensions
{
    public static IServiceCollection ApplicationRegistrationServices(IServiceCollection services)
    {
        services.AddDbContext<ApplecationDBContext>();
        return services;
    }
}