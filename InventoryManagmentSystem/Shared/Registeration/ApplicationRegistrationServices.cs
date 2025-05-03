using InventoryManagmentSystem.Features.AccountManagement.Services;
using InventoryManagmentSystem.Features.ProductManagement.Jobs;
using InventoryManagmentSystem.Features.ReportingManagement.Jobs;
using InventoryManagmentSystem.Features.ReportingManagement.Repository;
using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.GlobalErrorHandler;
using InventoryManagmentSystem.Shared.UnitOfWorks;

namespace InventoryManagmentSystem.Shared.Registeration;
public static class ApplicationRegistrationExtensions
{
    public static IServiceCollection ApplicationRegistrationServices(this IServiceCollection services)
    {
        services.AddScoped<IArchivedTransaction,ArchivedTransaction>();
        services.AddScoped<IDailyLowStockProducts , DailyLowStockProducts>();
        // services.AddScoped<GlobalErrorHandlerMiddleware>();
        services.AddScoped<TransactionProcessMiddleware>();
        services.AddScoped<IRegisterService, RegisterService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}