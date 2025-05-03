using System.Reflection;
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hangfire;
using InventoryManagmentSystem.Features.AccountManagement.Models;
using InventoryManagmentSystem.Features.ProductManagement.Jobs;
using InventoryManagmentSystem.Features.ReportingManagement.Jobs;
using InventoryManagmentSystem.Shared.Configuration;
using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.GlobalErrorHandler;
using InventoryManagmentSystem.Shared.Registeration;
using InventoryManagmentSystem.Shared.TransactionProcess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.ApplicationRegistrationServices();

builder.Services.Configure<JWT>(builder.Configuration.GetSection(JWT.SectionName));

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.RequireHttpsMetadata = false;
    option.SaveToken = true;
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
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



builder.Services.AddHangfire(configuration => configuration
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(builder.Configuration.GetConnectionString("LogsConnectionString")));

// Add the processing server as IHostedService
builder.Services.AddHangfireServer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseGlobalErrorHandler();
app.UseTransactionProcessHandler();

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseHangfireDashboard();

RecurringJob.AddOrUpdate<IDailyLowStockProducts>("DailyLowStockProducts", (DailyLowStock) => DailyLowStock.Notify(), Cron.Daily);
RecurringJob.AddOrUpdate<IArchivedTransaction>("ArchiveJob", (archive) => archive.Notify(), Cron.Monthly);

app.MapControllers();

app.Run();