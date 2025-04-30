
using InventoryManagmentSystem.Shared.APIResult;

namespace InventoryManagmentSystem.Shared.GlobalErrorHandler;

public class GlobalErrorHandlerMiddel : IMiddleware
{
    private readonly ILogger<GlobalErrorHandlerMiddel> logger;

    public GlobalErrorHandlerMiddel(ILogger<GlobalErrorHandlerMiddel> logger)
    {
        this.logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
          await next(context);
        }
        catch(Exception ex)
        {
            logger.LogError(ex.Message);
           await context.Response.WriteAsJsonAsync(Result<bool>.Failure(ex.Message));
        }
    }
}