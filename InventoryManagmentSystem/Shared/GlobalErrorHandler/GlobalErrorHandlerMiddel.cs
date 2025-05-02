
using InventoryManagmentSystem.Shared.APIResult;

namespace InventoryManagmentSystem.Shared.GlobalErrorHandler;

public class GlobalErrorHandlerMiddleware : IMiddleware
{
    private readonly ILogger<GlobalErrorHandlerMiddleware> logger;

    public GlobalErrorHandlerMiddleware(ILogger<GlobalErrorHandlerMiddleware> logger)
    {
        this.logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            await context.Response.WriteAsJsonAsync(Result<bool>.Failure(ex.Message));
        }
    }
}