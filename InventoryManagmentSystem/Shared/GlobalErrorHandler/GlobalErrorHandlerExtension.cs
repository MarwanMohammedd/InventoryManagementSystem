namespace InventoryManagmentSystem.Shared.GlobalErrorHandler;

public static class GlobalErrorHandlerExtension
{
    public static void UseGlobalErrorHandler(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseMiddleware<GlobalErrorHandlerMiddel>();
    }
}