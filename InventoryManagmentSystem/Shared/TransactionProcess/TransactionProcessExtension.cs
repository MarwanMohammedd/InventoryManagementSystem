
using InventoryManagmentSystem.Shared.Registeration;

namespace InventoryManagmentSystem.Shared.TransactionProcess;

public static class TransactionProcessExtension 
{
     public static void UseTransactionProcessHandler(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseMiddleware<TransactionProcessMiddelWare>();
    }
}