using System.Reflection;
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hangfire;
using InventoryManagmentSystem.Features.AccountManagement.Register;
using InventoryManagmentSystem.Features.Jobs;
using InventoryManagmentSystem.Shared.Configuration;
using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.GlobalErrorHandler;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.Registeration;
using InventoryManagmentSystem.Shared.TransactionProcess;
using InventoryManagmentSystem.Shared.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

builder.Services.AddScoped<IRegisterService, RegisterService>();

builder.Services.Configure<JWT>(builder.Configuration.GetSection(JWT.SectionName));


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.RequireHttpsMetadata = false;
    option.SaveToken = false;
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!))

    };
});


builder.Services.AddDbContext<ApplecationDBContext>(
    option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
    }
);


builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
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

app.UseAuthentication();
app.UseAuthorization();


app.UseHangfireDashboard();

RecurringJob.AddOrUpdate<DailyLowStockProducts>("DailyLowStockProducts", (DailyLowStock) => DailyLowStock.Notify(), Cron.Daily);
RecurringJob.AddOrUpdate<ArchivedTransaction>("ArchiveJob", (archive) => archive.Notify(), Cron.Yearly);

app.MapControllers();

app.Run();