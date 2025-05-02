using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hangfire;
using InventoryManagmentSystem.Features.Jobs;
using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.GlobalErrorHandler;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.Registeration;
using InventoryManagmentSystem.Shared.TransactionProcess;
using InventoryManagmentSystem.Shared.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<ArchivedTransaction>();
builder.Services.AddScoped<DailyLowStockProducts>();
builder.Services.AddScoped<GlobalErrorHandlerMiddleware>();
builder.Services.AddScoped<TransactionProcessMiddleware>();


builder.Services.AddDbContext<ApplecationDBContext>(
    option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
    }
);


builder.Services.AddIdentity<ApplicationUser , ApplicationRole>()
.AddEntityFrameworkStores<ApplecationDBContext>();
// .AddDefaultTokenProviders();

builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();


builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddHangfire(configuration => configuration
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnectionString")));

// Add the processing server as IHostedService
builder.Services.AddHangfireServer();

// builder.Logging.ClearProviders();

// Serilog.Log.Logger = new LoggerConfiguration()
// // .WriteTo.Seq("url:5341") tool for display logs <use it marwan>
// .WriteTo.MSSqlServer(
//      connectionString: builder.Configuration.GetConnectionString("LogsConnectionString"),
//         sinkOptions: new MSSqlServerSinkOptions
//         {
//             AutoCreateSqlDatabase = true,
//             AutoCreateSqlTable = true,
//             TableName = "Logs"
//         },
//         restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information
// ).CreateLogger();

// builder.Host.UseSerilog();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGlobalErrorHandler();
app.UseTransactionProcessHandler();

app.UseHttpsRedirection();

app.UseHangfireDashboard();

RecurringJob.AddOrUpdate<DailyLowStockProducts>("DailyLowStockProducts", (DailyLowStock) => DailyLowStock.Notify(), Cron.Daily);
RecurringJob.AddOrUpdate<ArchivedTransaction>("ArchiveJob", (archive) => archive.Notify(), Cron.Yearly);

app.MapControllers();

app.Run();